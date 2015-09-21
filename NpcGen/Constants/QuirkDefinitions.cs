using System.Collections.Generic;
using NpcGen.Models.NpcModels;
using NpcGen.Models.NpcModels.NpcModels;

namespace NpcGen.Constants
{
    public static class QuirkDefinitions
    {
        public static List<QuirkModel> List()
        {
            var list = new List<QuirkModel>();

            list.AddRange(Nice());
            list.AddRange(Nasty());
            list.AddRange(Misc());

            return list;
        }

        public static List<QuirkModel> Nice()
        {
            var list = new List<QuirkModel>
            {
                new QuirkModel{Description = "loves animals"},
                new QuirkModel{Description = "has a genuinely nice smile"},
                new QuirkModel{Description = "has impeccable manners"},
                new QuirkModel{Description = "greets friends with big hugs"}
            };

            return list;
        }

        public static List<QuirkModel> Nasty()
        {
            var list = new List<QuirkModel>
            {
                new QuirkModel{Description = "kicks animals"},
                new QuirkModel{Description = "has a genuinely foul odour"},
                new QuirkModel{Description = "has no manners at all"},
                new QuirkModel{Description = "greets strangers with a hateful glare"}
            };

            return list;
        }

        public static List<QuirkModel> Misc()
        {
            var list = new List<QuirkModel>{
                 new QuirkModel{Description = "Carries a large coin which he or she is always rolling over his or her knuckles."},
                 new QuirkModel{Description = "Is a habitual sniffler even when he or she is healthy."},
                 new QuirkModel{Description = "Regularly looks up at the sky to check the position of the sun/moon and comments on it."},
                 new QuirkModel{Description = "Always knows the direction he or she is traveling in (which really annoys my wife)."},
                 new QuirkModel{Description = "Corrects people when they use colloquial speech."},
                 new QuirkModel{Description = "Is never seen without a baseball cap or stocking cap (except, of course, in bed or the shower)"},
                 new QuirkModel{Description = "Whistles the Scarecrow/Tin Man/Cowardly Lion song at random time and refuses to stop."},
                 new QuirkModel{Description = "Ends declarative sentences with in interrogative inflection?"},
                 new QuirkModel{Description = "Is a mush mouth."},
                 new QuirkModel{Description = "Is an incessant fidgeter and is always touching his or her face or head."},
                 new QuirkModel{Description = "Dots his or her i’s with a smiley face or heart (respectively or inversely for humor’s sake)."},
                 new QuirkModel{Description = "Is unable to digest proteins correctly and gets very ill if too much protein rich food is consumed."},
                 new QuirkModel{Description = "Compulsively interrupts people telling stories to interject facts about the story that he or she only knows because they have been told the story before, not because they were involved with it."},
                 new QuirkModel{Description = "Makes up random lies about unimportant things for no reason."},
                 new QuirkModel{Description = "Has a weakness for rescuing stray animals."},
                 new QuirkModel{Description = "Gets physically angry when people mispronounce a certain word (e.g Illinois, precedent as president, especially as expecially)."},
                 new QuirkModel{Description = "(cheat) Regularly mispronounces a certain word or uses redundant terms (e.g. PIN number, ATM machine, Hot water heater–if it’s hot, does it need to be heated?)."},
                 new QuirkModel{Description = "When stressed or lying, speaks from the corner of his or her mouth."},
                 new QuirkModel{Description = "Profusely sweats even when at rest."},
                 new QuirkModel{Description = "Is unable to take advice from anyone because he or she thinks that they know it all."},
                 new QuirkModel{Description = "Uses mundane items as toys (e.g. bottle caps, straws, chopsticks)."},
                 new QuirkModel{Description = "Cannot drink anything with ice in it."},
                 new QuirkModel{Description = "Is strongly susceptible to \"brain freeze.\""},
                 new QuirkModel{Description = "Doesn’t wash his or her hands after using the bathroom."},
                 new QuirkModel{Description = "When dining out, always tidies up the table and resets the condiments."},
                 new QuirkModel{Description = "Walks in the middle of any aisle, sidewalk, or other shared walkway causing people to have to move around him or her."},
                 new QuirkModel{Description = "Drags his or her feet."},
                 new QuirkModel{Description = "Only drinks from eathenware or wooden cups and cannot stand the feel of glass in his or her hand."},
                 new QuirkModel{Description = "Draws random doodles on any piece of paper in front of him or her and always carries a pen or pencil to facilitate this habit."},
                 new QuirkModel{Description = "Wears only new socks."},
                 new QuirkModel{Description = "Has several hidden body piercings or tattoos that regular clothing conceal."},
                 new QuirkModel{Description = "Always stands with his or her hands behind their back, sometimes in an \"at ease\" position, though he or she was never in the military."},
                 new QuirkModel{Description = "Excessively uses initials or acronyms for common AND uncommon phrases and doesn’t bother to explain them."},
                 new QuirkModel{Description = "Doesn’t eat green things."},
                 new QuirkModel{Description = "Strongly dislikes the sound of chewing and hums a quiet song while eating."},
                 new QuirkModel{Description = "Has the ability to speak in a cartoon-like voice which sounds little or nothing like his or her real voice."},
                 new QuirkModel{Description = "Is thrifty nearly to the point of obsessive or compulsive nature."},
                 new QuirkModel{Description = "Is always at least ten minutes early to any meeting or appointment."},
                 new QuirkModel{Description = "Can calculate the total of any items put in a shopping cart and tax to within $0.05."},
                 new QuirkModel{Description = "Generally submits to the ideas and suggestions of others without thinking of his or her own needs."},
                 new QuirkModel{Description = "Readily puts him or her self in the way of danger without careful consideration."},
                 new QuirkModel{Description = "Always has change in his or her pocket to give to beggars or homeless."},
                 new QuirkModel{Description = "Is always trying to recruit people to his or her religious/philosophical beliefs."},
                 new QuirkModel{Description = "Constantly quotes favorite movies and can usually identify the movie that a quote may come from."},
                 new QuirkModel{Description = "Overly honest person, always telling the truth even to his or her own detriment."},
                 new QuirkModel{Description = "Takes stupid bets/dares for small amounts of money."},
                 new QuirkModel{Description = "Has several parts of his or her body that are double jointed and bend or flex in an unnatural or uncanny manner."},
                 new QuirkModel{Description = "Writes with left hand, but does everything else right-handed."},
                 new QuirkModel{Description = "Can only see out of one eye or hear out of one ear."},
                 new QuirkModel{Description = "Is susceptible to malapropisms or spoonerisms."}
            };

            return list;
        }
    }
}