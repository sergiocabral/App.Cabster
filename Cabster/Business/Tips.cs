using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Cabster.Extensions;
using Cabster.Infrastructure;

namespace Cabster.Business
{
    /// <summary>
    ///     Texto de dicas aleatórias.
    /// </summary>
    public class Tips: ITips
    {
        /// <summary>
        /// Construtor.
        /// </summary>
        public Tips()
        {
            this.LogClassInstantiate();
        }
        
        /// <summary>
        ///     Idioma padrão.
        /// </summary>
        private const string DefaultLanguage = "en";

        /// <summary>
        ///     Chave: Url
        /// </summary>
        private const string KeyUrl = "url";

        /// <summary>
        ///     Chave: Título
        /// </summary>
        private const string KeyTitle = "title";

        /// <summary>
        ///     Chave: Corpo do texto
        /// </summary>
        private const string KeyBody = "body";

        /// <summary>
        ///     Chave: Autor.
        /// </summary>
        private const string KeyAuthor = "author";

        /// <summary>
        ///     Chave: Texto traduzido.
        /// </summary>
        private const string KeyTranslated = "translated";

        /// <summary>
        ///     Lista de frases.
        /// </summary>
        private static readonly IList<IDictionary<string, string>> List = new List<IDictionary<string, string>>
        {
            new Dictionary<string, string>
            {
                {KeyUrl, "http://llewellynfalco.blogspot.com/2014/06/llewellyns-strong-style-pairing.html"},
                {KeyTitle, "Driver/Navigator Pattern"},
                {KeyBody, "For an idea to go from your head into the computer it MUST go through someone else's hands"},
                {KeyAuthor, "Llewellyn Falco"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://llewellynfalco.blogspot.com/2014/06/llewellyns-strong-style-pairing.html"},
                {KeyTitle, "Trust your navigator"},
                {
                    KeyBody,
                    "The right time to discuss and challenge design decisions is after the solution is out of the navigator's head."
                },
                {KeyAuthor, "Llewellyn Falco"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://llewellynfalco.blogspot.com/2014/06/llewellyns-strong-style-pairing.html"},
                {KeyTitle, "Driving With An Idea"},
                {KeyBody, "What if I have an idea I want to implement? Great! Switch places and become the navigator."},
                {KeyAuthor, "Llewellyn Falco"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "https://github.com/MobProgramming/MobTimer.Python/blob/master/Tips/MobProgramming"},
                {KeyTitle, "Mob Decision-Making"},
                {
                    KeyBody,
                    "Arguing about solutions? Try going with the least experienced navigator and have the more experienced team members course correct only as needed."
                },
                {KeyAuthor, "The Hunter Mob"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "https://www.infoq.com/news/2016/06/mob-programming-zuill"},
                {KeyTitle, "Lean Thinking"},
                {
                    KeyBody,
                    "The goal is not to be productive but effective. To draw a line with Lean Practices, being productive and not effective is usually a good way to produce waste quickly."
                },
                {KeyAuthor, "Woody Zuill"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "https://www.infoq.com/news/2016/06/mob-programming-zuill"},
                {KeyTitle, "Mob Programming"},
                {
                    KeyBody,
                    "It's not about Mob Programming. It’s about discovering the principles and practices that are important in the context of the work you are doing, and the people you are working with."
                },
                {KeyAuthor, "Woody Zuill"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "https://agilein3minut.es/32"},
                {KeyTitle, "Shared Attention"},
                {
                    KeyBody,
                    "With everyone paying attention pretty often, we stay focused, never stay stuck for long, and make better choices."
                },
                {KeyAuthor, "Amitai Schleier"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "https://agilein3minut.es/32"},
                {KeyTitle, "Limit WIP"},
                {
                    KeyBody,
                    "Since there's no \"my bugfix\" or \"your feature\", we naturally limit our Work In Progress."
                },
                {KeyAuthor, "Amitai Schleier"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/"},
                {KeyTitle, "Agile Manifesto Value"},
                {KeyBody, "We have come to value individuals and interactions over processes and tools."},
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/"},
                {KeyTitle, "Agile Manifesto Value"},
                {KeyBody, "We have come to value working software over comprehensive documentation."},
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/"},
                {KeyTitle, "Agile Manifesto Value"},
                {KeyBody, "We have come to value customer collaboration over contract negotiation."},
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/"},
                {KeyTitle, "Agile Manifesto Value"},
                {KeyBody, "We have come to value responding to change over following a plan."},
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {
                    KeyBody,
                    "Our highest priority is to satisfy the customer through early and continuous delivery of valuable software."
                },
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {
                    KeyBody,
                    "Welcome changing requirements, even late in development. Agile processes harness change for the customer's competitive advantage."
                },
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {
                    KeyBody,
                    "Deliver working software frequently, from a couple of weeks to a couple of months, with a preference to the shorter timescale."
                },
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {KeyBody, "Business people and developers must work together daily throughout the project."},
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {
                    KeyBody,
                    "Build projects around motivated individuals. Give them the environment and support they need, and trust them to get the job done."
                },
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {
                    KeyBody,
                    "The most efficient and effective method of conveying information to and within a development team is face-to-face conversation."
                },
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {KeyBody, "Working software is the primary measure of progress."},
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {
                    KeyBody,
                    "Agile processes promote sustainable development. The sponsors, developers, and users should be able to maintain a constant pace indefinitely."
                },
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {KeyBody, "Continuous attention to technical excellence and good design enhances agility."},
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {KeyBody, "Simplicity--the art of maximizing the amount of work not done--is essential."},
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {KeyBody, "The best architectures, requirements, and designs emerge from self-organizing teams."},
                {KeyAuthor, "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {KeyUrl, "http://agilemanifesto.org/principles.html"},
                {KeyTitle, "Agile Manifesto Principle"},
                {
                    KeyBody,
                    "At regular intervals, the team reflects on how to become more effective, then tunes and adjusts its behavior accordingly."
                },
                {KeyAuthor, "Agile Manifesto Signatories"}
            }
        };

        /// <summary>
        ///     Última dica obtida.
        /// </summary>
        private int _index = new Random(DateTime.Now.Millisecond).Next(0, List.Count);

        /// <summary>
        ///     Obtem uma dica aleatória.
        /// </summary>
        /// <returns></returns>
        public async Task<string> Get()
        {
            var tip = List[_index++ % List.Count];

            if (tip.ContainsKey(KeyTranslated)) return tip[KeyTranslated];

            var translated = $"{tip[KeyTitle]}: {tip[KeyBody]}";

            if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName != DefaultLanguage)
                translated = await translated
                    .GoogleTranslate(DefaultLanguage, CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);

            tip[KeyTranslated] = $"{translated} — {tip[KeyAuthor]}";

            return tip[KeyTranslated];
        }
    }
}