using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NpcGen.Models.NpcModels;
using NpcGen.Extensions;

namespace NpcGen.Helpers
{
    public static class NpcViewHelper
    {
        public static MvcHtmlString RenderDescription(NpcModel model)
        {
            TagBuilder paragraph = new TagBuilder("p");
            paragraph.InnerHtml = string.Format(
                "{0} is {1} {2} {3}, distinguished from others because {4} {5}.",
                model.Name,
                model.Demeanour.FirstOrDefault().Description.WithArticle(),
                EnumExtensions.ToName(model.Age).ToLower(),
                model.Class.Name, model.Pers(),
                model.Quirks.FirstOrDefault().
                Description.NotCap().Genderize(model.Gender)
                );
            return MvcHtmlString.Create(paragraph.ToString());
        }

        public static MvcHtmlString RenderAppearance(NpcModel model)
        {
            TagBuilder paragraph = new TagBuilder("p");
            paragraph.InnerHtml = string.Format(
                "{0} has {1} and {2}.",
            model.Pers(true),
            model.Appearance.GeneralAppearance.ElementAt(0).Feature.ToLower(),
            model.Appearance.GeneralAppearance.ElementAt(1).Feature.ToLower()
            );

            return MvcHtmlString.Create(paragraph.ToString());
        }

        public static MvcHtmlString RenderClassSaves(NpcModel model)
        {
            TagBuilder paragraph = new TagBuilder("p");
            paragraph.InnerHtml = string.Format("{0} strong saves are ", model.Poss(true));
            foreach (var sv in model.ClassSaves)
            {
                if (sv != model.ClassSaves.First())
                {
                    paragraph.InnerHtml += ",";
                }

                TagBuilder bold = new TagBuilder("b");
                bold.InnerHtml = sv.Name.Replace(" Save", string.Empty);
                paragraph.InnerHtml += string.Format("{0} : {1}.", bold, model.Class.ProficientSkillScoreStringGet(sv));
            }
            return MvcHtmlString.Create(paragraph.ToString());
        }

        public static MvcHtmlString RenderClassSkills(NpcModel model)
        {
            TagBuilder paragraph = new TagBuilder("p");

            paragraph.InnerHtml = string.Format("{0} is skilled in ", model.Name);
            if (model.ClassSkills.Any())
            {
                foreach (var prof in model.ClassSkills)
                {
                    TagBuilder bold = new TagBuilder("b");
                    bold.InnerHtml = prof.Name;
                    paragraph.InnerHtml += bold.ToString();
                    paragraph.InnerHtml += string.Format(" ({0} : {1})", prof.Stat, model.Class.ProficientSkillScoreStringGet(prof));
                    paragraph.InnerHtml += ",";
                }
                TagBuilder otherBold = new TagBuilder("b");
                otherBold.InnerHtml = model.CustomProficiencies.FirstOrDefault().Name;
                paragraph.InnerHtml += string.Format("and curiously enough, also in {0} ({1} : {2})",
                    otherBold,
                    model.CustomProficiencies.FirstOrDefault().Stat,
                    model.Class.ProficientSkillScoreStringGet(model.CustomProficiencies.FirstOrDefault())
                    );
            }
            else
            {
                TagBuilder otherBold = new TagBuilder("b");
                otherBold.InnerHtml = model.CustomProficiencies.FirstOrDefault().Name;
                paragraph.InnerHtml += string.Format("{0} ({1} : {2})",
                    otherBold,
                    model.CustomProficiencies.FirstOrDefault().Stat,
                    model.Class.ProficientSkillScoreStringGet(model.CustomProficiencies.FirstOrDefault())
                    );
            }
            return MvcHtmlString.Create(paragraph.ToString());
        }

        public static MvcHtmlString RenderAttacks(NpcModel model)
        {
            TagBuilder paragraph = new TagBuilder("p");
            paragraph.InnerHtml = string.Format("{0} has the following attacks ", model.Name);
            var list = new TagBuilder("ul");
            foreach (var at in model.Class.Attacks)
            {

                TagBuilder listItem = new TagBuilder("li");
                listItem.InnerHtml = string.Format("{0} ({1} - {2} {3})",
                    at.Name,
                    at.ToHit.ToString(),
                    at.Damage,
                    model.Class.AbilityModifierGet(at.Ability).AbilityModStringGet());
                list.InnerHtml += listItem;
            }
            paragraph.InnerHtml += list;
            return MvcHtmlString.Create(paragraph.ToString());
        }
        public static MvcHtmlString RenderClassAbilities(NpcModel model)
        {
            TagBuilder paragraph = new TagBuilder("p");
            if (model.Class.ClassAbilities.Count > 0)
            {
                paragraph.InnerHtml = string.Format("As a typical {0}, {1} has the following abilities:", model.Class.Name, model.Name);
                var list = new TagBuilder("ul");
                foreach (var ab in model.Class.ClassAbilities)
                {
                    TagBuilder listItem = new TagBuilder("li");
                    listItem.InnerHtml = string.Format("<b>{0}</b> <br />{1}", ab.Name, ab.Description);
                    list.InnerHtml += listItem;
                }
                paragraph.InnerHtml += list;
            }
            return MvcHtmlString.Create(paragraph.ToString());
        }





    }
}