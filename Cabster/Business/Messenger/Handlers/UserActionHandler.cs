using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cabster.Business.Entities;
using Cabster.Business.Messenger.Request;
using Cabster.Business.Values;
using Cabster.Exceptions;
using Cabster.Infrastructure;
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
        IRequestHandler<UserActionGroupWorkStart>
    {
        /// <summary>
        /// Barramento de mensagens.
        /// </summary>
        private readonly IMediator _messageBus;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="messageBus">Barramento de mensagens.</param>
        public UserActionHandler(IMediator messageBus)
        {
            _messageBus = messageBus;
        }
        
        /// <summary>
        ///     Processa o comando: UserActionPoke
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public Task<Unit> Handle(UserActionPoke request, CancellationToken cancellationToken)
        {
            //TODO: Implementar UserActionPoke
            Log.Verbose(nameof(UserActionPoke));

            return Unit.Task;
        }
        
        /// <summary>
        ///     Processa o comando: UserActionGroupWorkStart
        /// </summary>
        /// <param name="request">Comando</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>Task</returns>
        public async Task<Unit> Handle(UserActionGroupWorkStart request, CancellationToken cancellationToken)
        {
            var data = Program.Data;

            var workers = data
                .GroupWork
                .Participants
                .Where(a => a.Active)
                .Take(2)
                .ToArray();
            
            if (workers.Length != 2)
            {
                await _messageBus.Send(
                    new UserNotificationPost(
                        new NotificationMessage(
                            "É necessário pelo menos dois participantes.", false), 
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

            data.GroupWork.Timer.Running = true;
            data.GroupWork.Timer.Driver = driver.Name;
            data.GroupWork.Timer.Navigator = navigator.Name;
            data.GroupWork.Timer.Limit = DateTimeOffset.Now.AddMinutes(data.GroupWork.Times.TimeToWork);
            await _messageBus.Send(
                new DataUpdate(data, 
                    DataSection.WorkGroupParticipants | DataSection.WorkGroupTimer), cancellationToken);

            await _messageBus.Send(new WindowOpen(Window.GroupWorkTimer, Form.ActiveForm), cancellationToken);

            return Unit.Value;
        }
    }
}