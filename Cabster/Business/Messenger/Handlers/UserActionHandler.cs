using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Entities;
using Cabster.Business.Forms;
using Cabster.Business.Messenger.Request;
using Cabster.Business.Values;
using Cabster.Exceptions;
using Cabster.Infrastructure;
using Cabster.Properties;
using MediatR;
using Serilog;

namespace Cabster.Business.Messenger.Handlers
{
    /// <summary>
    ///     Ações do usuário.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class UserActionHandler :
        MessengerHandler,
        IRequestHandler<UserActionPoke>,
        IRequestHandler<UserActionGroupWorkTimerWorkStart>,
        IRequestHandler<UserActionGroupWorkTimerBreakStart>,
        IRequestHandler<UserActionGroupWorkTimerEnd>
    {
        /// <summary>
        /// Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        /// Bloqueador de telas.
        /// </summary>
        private readonly ILockScreen _lockScreen;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="messageBus">Barramento de mensagens.</param>
        /// <param name="lockScreen">Bloqueador de telas.</param>
        public UserActionHandler(IMediator messageBus, ILockScreen lockScreen)
        {
            _messageBus = messageBus;
            _lockScreen = lockScreen;
        }
        
        /// <summary>
        ///     Processa o comando: UserActionPoke
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(UserActionPoke request, CancellationToken cancellationToken)
        {
            var data = Program.Data;
            switch (data.Application.State)
            {
                case ApplicationState.Idle:
                    var formGroupWork = Program.DependencyResolver.GetInstanceRequired<FormGroupWork>();
                    formGroupWork.WindowState =
                        formGroupWork.WindowState == FormWindowState.Minimized
                            ? FormWindowState.Normal
                            : FormWindowState.Minimized;
                    break;
                case ApplicationState.GroupWorkTimerForWork:
                case ApplicationState.GroupWorkTimerForBreak:
                    var formGroupWorkTimer = Program.DependencyResolver.GetInstanceRequired<FormGroupWorkTimer>();
                    formGroupWorkTimer.Pause();
                    break;
            }
            return Unit.Task;
        }
        
        /// <summary>
        ///     Processa o comando: UserActionGroupWorkStart
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(UserActionGroupWorkTimerWorkStart request, CancellationToken cancellationToken)
        {
            var data = Program.Data;

            var workers = data
                .GroupWork
                .Participants
                .Where(a => a.Active)
                .Take(2)
                .ToArray();

            data.Application.State = ApplicationState.GroupWorkTimerForWork;

            if (workers.Length != 2)
            {
                await _messageBus.Send(
                    new UserNotificationPost(
                        new NotificationMessage(
                            Resources.Exception_GroupWork_TwoParticipantsAreRequired, false), 
                        request), cancellationToken);
                return Unit.Value;
            }
            
            var driver = workers[0];
            var navigator = workers[1];

            data.GroupWork.Participants.Remove(driver);
            data.GroupWork.Participants.Add(driver);
            while (!data.GroupWork.Participants[0].Active)
            {
                var inactiveGoToEndOfTheList = data.GroupWork.Participants[0];
                data.GroupWork.Participants.Remove(inactiveGoToEndOfTheList);
                data.GroupWork.Participants.Add(inactiveGoToEndOfTheList);
            }

            data.GroupWork.History.Add(new GroupWorkHistorySet
            {
                Started = DateTimeOffset.UtcNow,
                TimeExpected = TimeSpan.FromMinutes(data.GroupWork.Times.TimeToWork),
                TimeElapsed = TimeSpan.Zero,
                TimeConcluded = false,
                IsBreak = false,
                Driver = driver.Name,
                Navigator = navigator.Name
            });
            
            await _messageBus.Send(new DataUpdate(data,
                DataSection.ApplicationState | DataSection.WorkGroupParticipants | DataSection.WorkGroupHistory), 
                cancellationToken);

            await _messageBus.Send(new WindowClose(Window.All), cancellationToken);
            
            await _messageBus.Send(new WindowOpen(Window.GroupWorkTimer, Form.ActiveForm), cancellationToken);

            if (data.Application.LockScreen) _lockScreen.Unlock();
                
            return Unit.Value;
        }
        
        /// <summary>
        ///     Processa o comando: UserActionGroupWorkStartBreak
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(UserActionGroupWorkTimerBreakStart request, CancellationToken cancellationToken)
        {
            var data = Program.Data;

            data.Application.State = ApplicationState.GroupWorkTimerForBreak;

            data.GroupWork.History.Add(new GroupWorkHistorySet
            {
                Started = DateTimeOffset.UtcNow,
                TimeExpected = TimeSpan.FromMinutes(data.GroupWork.Times.TimeToWork),
                TimeElapsed = TimeSpan.Zero,
                TimeConcluded = false,
                IsBreak = true,
                Driver = null, 
                Navigator = null
            });
            
            await _messageBus.Send(new DataUpdate(data,
                DataSection.ApplicationState | DataSection.WorkGroupHistory), 
                cancellationToken);

            await _messageBus.Send(new WindowClose(Window.All), cancellationToken);
            
            await _messageBus.Send(new WindowOpen(Window.GroupWorkTimer, Form.ActiveForm), cancellationToken);

            if (data.Application.LockScreen) _lockScreen.Unlock();
                
            return Unit.Value;
        }
        
        /// <summary>
        ///     Processa o comando: UserActionGroupWorkTimerEnd
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(UserActionGroupWorkTimerEnd request, CancellationToken cancellationToken)
        {
            var data = Program.Data;

            var current = data.GroupWork.History.Last();
            current.TimeElapsed = request.Elapsed;
            current.TimeConcluded = request.Concluded;

            data.Application.State = ApplicationState.Idle;
            
            await _messageBus.Send(new DataUpdate(data, 
                DataSection.ApplicationState | DataSection.WorkGroupHistory), cancellationToken);
            
            await _messageBus.Send(new WindowClose(Window.All), cancellationToken);

            await _messageBus.Send(new WindowOpen(Window.GroupWork), cancellationToken);
            
            if (data.Application.LockScreen) _lockScreen.Lock();
            
            Log.Verbose("Elapsed: {elapsed}", request.Elapsed);
            
            return Unit.Value;
        }
    }
}