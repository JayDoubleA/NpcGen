using System.Linq;
using System.Web.Mvc;
using NpcGen.Extensions;
using NpcGen.Models.NpcModels;

namespace NpcGen.Helpers
{
    public static class NpcViewHelper
    {
        public static MvcHtmlString RenderDescription(NpcModel model)
        {
            var paragraph = new TagBuilder("p");
            var firstOrDefault = model.Demeanour.FirstOrDefault();
            if (firstOrDefault != null)
            {
                var quirkModel = model.Quirks.FirstOrDefault();
                if (quirkModel != null)
                    paragraph.InnerHtml = string.Format(
                        "{0} is {1} {2} {3}, distinguished from others because {4} {5}.",
                        model.Name,
                        firstOrDefault.Description.WithArticle(),
                        EnumExtensions.ToName(model.Age).ToLower(),
                        model.Class.Name, model.Pers(),
                        quirkModel.
                            Description.NotCap().Genderize(model.Gender)
                        );
            }
            return MvcHtmlString.Create(paragraph.ToString());
        }

        public static MvcHtmlString RenderAppearance(NpcModel model)
        {
            var paragraph = new TagBuilder("p")
            {
                InnerHtml = string.Format(
                    "{0} face is defined by {1} {2} and {3} eyes. {0} hair is {4} and {5}.",
                    model.Poss(true),
                    model.Poss(),
                    model.Appearance.FacialFeatures.Replace("{pos", model.Poss()).ToLower(),
                    model.Appearance.EyeColour.ToLower(),
                    model.Appearance.HairColor.ToLower(),
                    model.Appearance.HairStyle.ToLower()
                    )
            };

            return MvcHtmlString.Create(paragraph.ToString());
        }

        public static MvcHtmlString RenderClassSaves(NpcModel model)
        {
            var paragraph = new TagBuilder("p") {InnerHtml = string.Format("{0} strong saves are ", model.Poss(true))};
            foreach (var sv in model.ClassSaves)
            {
                if (sv != model.ClassSaves.First())
                {
                    paragraph.InnerHtml += ",";
                }

                var bold = new TagBuilder("b") {InnerHtml = sv.Name.Replace(" Save", string.Empty)};
                paragraph.InnerHtml += string.Format("{0} : {1}.", bold, model.Class.ProficientSkillScoreStringGet(sv));
            }
            return MvcHtmlString.Create(paragraph.ToString());
        }

        public static MvcHtmlString RenderClassSkills(NpcModel model)
        {
            var paragraph = new TagBuilder("p") {InnerHtml = string.Format("{0} is skilled in ", model.Name)};

            if (model.ClassSkills.Any())
            {
                foreach (var prof in model.ClassSkills)
                {
                    var bold = new TagBuilder("b") {InnerHtml = prof.Name};
                    paragraph.InnerHtml += bold.ToString();
                    paragraph.InnerHtml += string.Format(" ({0} : {1})", prof.Ability,
                        model.Class.ProficientSkillScoreStringGet(prof));
                    paragraph.InnerHtml += ",";
                }
                var firstOrDefault = model.CustomProficiencies.FirstOrDefault();
                if (firstOrDefault != null)
                {
                    var otherBold = new TagBuilder("b") {InnerHtml = firstOrDefault.Name};
                    paragraph.InnerHtml += string.Format("and curiously enough, also in {0} ({1} : {2})",
                        otherBold,
                        firstOrDefault.Ability,
                        model.Class.ProficientSkillScoreStringGet(firstOrDefault)
                        );
                }
            }
            else
            {
                var firstOrDefault = model.CustomProficiencies.FirstOrDefault();
                if (firstOrDefault != null)
                {
                    var otherBold = new TagBuilder("b") {InnerHtml = firstOrDefault.Name};
                    paragraph.InnerHtml += string.Format("{0} ({1} : {2})",
                        otherBold,
                        firstOrDefault.Ability,
                        model.Class.ProficientSkillScoreStringGet(firstOrDefault)
                        );
                }
            }
            return MvcHtmlString.Create(paragraph.ToString());
        }

        public static MvcHtmlString RenderAttacks(NpcModel model)
        {
            var paragraph = new TagBuilder("p")
            {
                InnerHtml = string.Format("{0} has the following attacks ", model.Name)
            };
            var list = new TagBuilder("ul");
            foreach (var at in model.Class.Attacks)
            {
                var listItem = new TagBuilder("li")
                {
                    InnerHtml = string.Format("{0} ({1} - {2} {3})",
                        at.Name,
                        at.ToHit,
                        at.Damage,
                        model.Class.AbilityModifierGet(at.Ability).AbilityModStringGet())
                };
                list.InnerHtml += listItem;
            }
            paragraph.InnerHtml += list;
            return MvcHtmlString.Create(paragraph.ToString());
        }

        public static MvcHtmlString RenderClassAbilities(NpcModel model)
        {
            var paragraph = new TagBuilder("p");
            if (model.Class.ClassAbilities.Count > 0)
            {
                paragraph.InnerHtml = string.Format("As a typical {0}, {1} has the following abilities:",
                    model.Class.Name, model.Name);
                var list = new TagBuilder("ul");
                foreach (var ab in model.Class.ClassAbilities)
                {
                    var listItem = new TagBuilder("li")
                    {
                        InnerHtml = string.Format("<b>{0}</b> <br />{1}", ab.Name, ab.Description)
                    };
                    list.InnerHtml += listItem;
                }
                paragraph.InnerHtml += list;
            }
            return MvcHtmlString.Create(paragraph.ToString());
        }
    }
}