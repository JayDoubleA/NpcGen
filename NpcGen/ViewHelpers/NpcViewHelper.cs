using System.Linq;
using System.Web.Mvc;
using NpcGen.Extensions;
using NpcGen.Models.NpcModels;

namespace NpcGen.ViewHelpers
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
                        "{0} is {1} {2} {3} {4}, hailing from {5}, distinguished from others because {6} {7}.",
                        model.Name,
                        firstOrDefault.Description.WithArticle(),
                        EnumExtensions.ToName(model.Age).ToLower(),
                        model.RaceModel.Name,
                        model.Class.Name,
                        model.Location.Name,
                        model.Pers(),
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
                    "{0} face is defined by {1} {2} and {3}. {4}",
                    model.Poss(true),
                    model.Poss(),
                    model.Appearance.FacialFeatures.Replace("{pos}", model.Poss()).ToLower(),
                    model.Appearance.EyeColour.ToLower(),
                    model.Appearance.Hair.ToSentenceCase()
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
                paragraph.InnerHtml += string.Format("{0} : {1}", bold, model.Class.ProficientSkillScoreStringGet(sv));
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
                    paragraph.InnerHtml += string.Format(" ({0} : {1})", prof.Ability, model.Class.ProficientSkillScoreStringGet(prof));
                    paragraph.InnerHtml += ",";
                }
            }

            if (model.CustomProficiencies != null && model.CustomProficiencies.Any())
            {
                paragraph.InnerHtml += model.ClassSkills.Any() ? " and curiously enough, also in " : string.Empty;

                foreach (var prof in model.CustomProficiencies)
                {
                    var otherBold = new TagBuilder("b") { InnerHtml = prof.Name };
                    paragraph.InnerHtml += otherBold.ToString();
                    paragraph.InnerHtml += string.Format(" ({0} : {1})", prof.Ability, model.Class.ProficientSkillScoreStringGet(prof));
                    paragraph.InnerHtml += ", ";
                }
            }

            var txt = paragraph.ToString();
            if (txt.EndsWith(", </p>"))
            {
                txt = txt.Replace(", </p>", ".</p>");
            }

            return MvcHtmlString.Create(txt);
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
                var toHit = at.ToHit >= 0 ? string.Format("+{0}", at.ToHit) : at.ToHit.ToString();

                var special = string.Empty;
                if (at.Special.NotNullOrEmpty())
                {
                    special = string.Format("&nbsp;<i>{0}</i>", at.Special);
                }

                var listItem = new TagBuilder("li")
                {
                    InnerHtml = string.Format("{0} : <b>{1}</b> for <b>{2}{3}</b> {4}",
                        at.Name,
                        toHit,
                        at.Damage,
                        model.Class.AbilityModifierGet(at.Ability).AbilityModStringGet(),
                        special)
                };
                list.InnerHtml += listItem;
            }
            paragraph.InnerHtml += list;
            return MvcHtmlString.Create(paragraph.ToString());
        }

        public static MvcHtmlString RenderAbilities(NpcModel model)
        {
            var paragraph = new TagBuilder("p");
            if (model.ClassAbilities.Count > 0 || model.RaceModel.RaceAbilities.Count > 0)
            {
                paragraph.InnerHtml = string.Format("As a typical {0} {1}, {2} has the following abilities:", model.RaceModel.Name, model.Class.Name, model.Name);
                var list = new TagBuilder("ul");
                foreach (var ab in model.Class.ClassAbilities)
                {
                    var listItem = new TagBuilder("li")
                    {
                        InnerHtml = string.Format("<b>{0}</b> <br />{1}", ab.Name, ab.Description)
                    };
                    list.InnerHtml += listItem;
                }
                foreach (var ab in model.RaceModel.RaceAbilities)
                {
                    var listItem = new TagBuilder("li")
                    {
                        InnerHtml = string.Format("<b>{0}</b> <br />{1}", ab.Name, ab.Description.DescriptionPronounify(model))
                    };
                    list.InnerHtml += listItem;
                }
                paragraph.InnerHtml += list;
            }
            return MvcHtmlString.Create(paragraph.ToString());
        }
    }
}