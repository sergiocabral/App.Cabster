using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Cabster.Extensions;

namespace Cabster.Business
{
    /// <summary>
    ///     Texto de dicas aleatórias.
    /// </summary>
    public static class Tips
    {
        /// <summary>
        ///     Idioma padrão.
        /// </summary>
        private const string DefaultLanguage = "en";

        /// <summary>
        ///     Random.
        /// </summary>
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        ///     Lista de frases.
        /// </summary>
        private static readonly IList<IDictionary<string, string>> List = new List<IDictionary<string, string>>
        {
            new Dictionary<string, string>
            {
                {"url", "http://llewellynfalco.blogspot.com/2014/06/llewellyns-strong-style-pairing.html"},
                {"title", "Driver/Navigator Pattern"},
                {"body", "For an idea to go from your head into the computer it MUST go through someone else's hands"},
                {"author", "Llewellyn Falco"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://llewellynfalco.blogspot.com/2014/06/llewellyns-strong-style-pairing.html"},
                {"title", "Trust your navigator"},
                {
                    "body",
                    "The right time to discuss and challenge design decisions is after the solution is out of the navigator's head."
                },
                {"author", "Llewellyn Falco"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://llewellynfalco.blogspot.com/2014/06/llewellyns-strong-style-pairing.html"},
                {"title", "Driving With An Idea"},
                {"body", "What if I have an idea I want to implement? Great! Switch places and become the navigator."},
                {"author", "Llewellyn Falco"}
            },
            new Dictionary<string, string>
            {
                {"url", "https://github.com/MobProgramming/MobTimer.Python/blob/master/Tips/MobProgramming"},
                {"title", "Mob Decision-Making"},
                {
                    "body",
                    "Arguing about solutions? Try going with the least experienced navigator and have the more experienced team members course correct only as needed."
                },
                {"author", "The Hunter Mob"}
            },
            new Dictionary<string, string>
            {
                {"url", "https://www.infoq.com/news/2016/06/mob-programming-zuill"},
                {"title", "Lean Thinking"},
                {
                    "body",
                    "The goal is not to be productive but effective. To draw a line with Lean Practices, being productive and not effective is usually a good way to produce waste quickly."
                },
                {"author", "Woody Zuill"}
            },
            new Dictionary<string, string>
            {
                {"url", "https://www.infoq.com/news/2016/06/mob-programming-zuill"},
                {"title", "Mob Programming"},
                {
                    "body",
                    "It's not about Mob Programming. It’s about discovering the principles and practices that are important in the context of the work you are doing, and the people you are working with."
                },
                {"author", "Woody Zuill"}
            },
            new Dictionary<string, string>
            {
                {"url", "https://agilein3minut.es/32"},
                {"title", "Shared Attention"},
                {
                    "body",
                    "With everyone paying attention pretty often, we stay focused, never stay stuck for long, and make better choices."
                },
                {"author", "Amitai Schleier"}
            },
            new Dictionary<string, string>
            {
                {"url", "https://agilein3minut.es/32"},
                {"title", "Limit WIP"},
                {
                    "body",
                    "Since there's no \"my bugfix\" or \"your feature\", we naturally limit our Work In Progress."
                },
                {"author", "Amitai Schleier"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/"},
                {"title", "Agile Manifesto Value"},
                {"body", "We have come to value individuals and interactions over processes and tools."},
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/"},
                {"title", "Agile Manifesto Value"},
                {"body", "We have come to value working software over comprehensive documentation."},
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/"},
                {"title", "Agile Manifesto Value"},
                {"body", "We have come to value customer collaboration over contract negotiation."},
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/"},
                {"title", "Agile Manifesto Value"},
                {"body", "We have come to value responding to change over following a plan."},
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {
                    "body",
                    "Our highest priority is to satisfy the customer through early and continuous delivery of valuable software."
                },
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {
                    "body",
                    "Welcome changing requirements, even late in development. Agile processes harness change for the customer's competitive advantage."
                },
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {
                    "body",
                    "Deliver working software frequently, from a couple of weeks to a couple of months, with a preference to the shorter timescale."
                },
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {"body", "Business people and developers must work together daily throughout the project."},
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {
                    "body",
                    "Build projects around motivated individuals. Give them the environment and support they need, and trust them to get the job done."
                },
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {
                    "body",
                    "The most efficient and effective method of conveying information to and within a development team is face-to-face conversation."
                },
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {"body", "Working software is the primary measure of progress."},
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {
                    "body",
                    "Agile processes promote sustainable development. The sponsors, developers, and users should be able to maintain a constant pace indefinitely."
                },
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {"body", "Continuous attention to technical excellence and good design enhances agility."},
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {"body", "Simplicity--the art of maximizing the amount of work not done--is essential."},
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {"body", "The best architectures, requirements, and designs emerge from self-organizing teams."},
                {"author", "Agile Manifesto Signatories"}
            },
            new Dictionary<string, string>
            {
                {"url", "http://agilemanifesto.org/principles.html"},
                {"title", "Agile Manifesto Principle"},
                {
                    "body",
                    "At regular intervals, the team reflects on how to become more effective, then tunes and adjusts its behavior accordingly."
                },
                {"author", "Agile Manifesto Signatories"}
            }
        };

        /// <summary>
        /// Última dica obtida.
        /// </summary>
        private static int _lastIndex = -1;

        /// <summary>
        ///     Obtem uma dica aleatória.
        /// </summary>
        /// <returns></returns>
        public static async Task<string> Get()
        {
            int index;
            do
            {
                index = Random.Next(0, List.Count);
            } while (index == _lastIndex);
            var tip = List[_lastIndex = index];

            if (tip.ContainsKey("_translated")) return Format(tip);

            var title = await tip["title"]
                .GoogleTranslate(DefaultLanguage, CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
            var body = await tip["body"]
                .GoogleTranslate(DefaultLanguage, CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);

            tip["_translated"] = "OK";
            tip["title"] = title;
            tip["body"] = body;

            return Format(tip);
        }

        /// <summary>
        ///     Formata a exibição de uma dicas.
        /// </summary>
        /// <param name="tip">Dica.</param>
        /// <returns>Texto formatado.</returns>
        private static string Format(IDictionary<string, string> tip)
        {
            return $"{tip["title"]}: {tip["body"]} — {tip["author"]}";
        }
    }
}