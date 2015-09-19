using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NpcGen.Models.NpcModels;

namespace NpcGen.Constants
{
    public class DemeanourDefinitions
    {
        public static List<DemeanourModel> List()
        {
            var list = new List<DemeanourModel>();

            list.AddRange(Nice());
            list.AddRange(Nasty());

            return list;
        }

        public static List<DemeanourModel> Nice()
        {
            var list = new List<DemeanourModel>
            {
                new DemeanourModel{Description = "affectionate"},                                 
                new DemeanourModel{Description = "affable"}, 
                new DemeanourModel{Description = "amiable"}, 
                new DemeanourModel{Description = "genial"}, 
                new DemeanourModel{Description = "congenial"}, 
                new DemeanourModel{Description = "cordial"}, 
                new DemeanourModel{Description = "warm"}, 
                new DemeanourModel{Description = "demonstrative"}, 
                new DemeanourModel{Description = "convivial"}, 
                new DemeanourModel{Description = "companionable"}, 
                new DemeanourModel{Description = "company-loving"}, 
                new DemeanourModel{Description = "sociable"}, 
                new DemeanourModel{Description = "gregarious"}, 
                new DemeanourModel{Description = "outgoing"}, 
                new DemeanourModel{Description = "clubbable"}, 
                new DemeanourModel{Description = "comradely"}, 
                new DemeanourModel{Description = "neighbourly"}, 
                new DemeanourModel{Description = "hospitable"}, 
                new DemeanourModel{Description = "approachable"}, 
                new DemeanourModel{Description = "easy to get along with"}, 
                new DemeanourModel{Description = "communicative"}, 
                new DemeanourModel{Description = "open"}, 
                new DemeanourModel{Description = "unreserved"}, 
                new DemeanourModel{Description = "easy-going"}, 
                new DemeanourModel{Description = "good-natured"}, 
                new DemeanourModel{Description = "kindly"}, 
                new DemeanourModel{Description = "benign"}, 
                new DemeanourModel{Description = "amenable"}, 
                new DemeanourModel{Description = "agreeable"}, 
                new DemeanourModel{Description = "obliging"}, 
                new DemeanourModel{Description = "sympathetic"}, 
                new DemeanourModel{Description = "well disposed"}, 
                new DemeanourModel{Description = "benevolent"},
                new DemeanourModel{Description = "couthy"},
                new DemeanourModel{Description = "chummy"}, 
                new DemeanourModel{Description = "pally"}, 
                new DemeanourModel{Description = "clubby"},
                new DemeanourModel{Description = "matey"}, 
                new DemeanourModel{Description = "decent"}
            };

            return list;
        }

        public static List<DemeanourModel> Nasty()
        {
            var list = new List<DemeanourModel>
            {
                new DemeanourModel{Description="unfriendly"},
                new DemeanourModel{Description="unsociable"},
                new DemeanourModel{Description="aloof"},
                new DemeanourModel{Description="hostile"},
                new DemeanourModel{Description="unpleasant"},
                new DemeanourModel{Description="disadvantageous"},
                new DemeanourModel{Description="harmful"},
                new DemeanourModel{Description="surly"},
                new DemeanourModel{Description="hurtful"},
                new DemeanourModel{Description="injurious"},
                new DemeanourModel{Description="ignorant"},
                new DemeanourModel{Description="unkind"},
                new DemeanourModel{Description="inaccurate"},
                new DemeanourModel{Description="antagonistic"},
                new DemeanourModel{Description="incompatible"},
                new DemeanourModel{Description="cold"},
                new DemeanourModel{Description="cool"},
                new DemeanourModel{Description="disagreeable"},
                new DemeanourModel{Description="hurting"},
                new DemeanourModel{Description="unhelpful"},
                new DemeanourModel{Description="inimical"},
                new DemeanourModel{Description="contentious"},
                new DemeanourModel{Description="belligerent"},
                new DemeanourModel{Description="unsympathetic"},
                new DemeanourModel{Description="adverse"},
                new DemeanourModel{Description="unfriendly"},
                new DemeanourModel{Description="inhospitable"},
                new DemeanourModel{Description="opposed"},
                new DemeanourModel{Description="hateful"},
                new DemeanourModel{Description="unfavorable"},
                new DemeanourModel{Description="contrary"},
                new DemeanourModel{Description="nasty"},
                new DemeanourModel{Description="bitter"},
                new DemeanourModel{Description="alien"},
                new DemeanourModel{Description="opposite"},
                new DemeanourModel{Description="catty"},
                new DemeanourModel{Description="militant"},
                new DemeanourModel{Description="sour"},
                new DemeanourModel{Description="cold"},
                new DemeanourModel{Description="chill"},
                new DemeanourModel{Description="allergic"},
                new DemeanourModel{Description="argumentative"},
                new DemeanourModel{Description="bellicose"},
                new DemeanourModel{Description="competitive"},
                new DemeanourModel{Description="dour"},
                new DemeanourModel{Description="malevolent"},
                new DemeanourModel{Description="malicious"},
                new DemeanourModel{Description="malignant"},
                new DemeanourModel{Description="ornery"},
                new DemeanourModel{Description="pugnacious"},
                new DemeanourModel{Description="spiteful"},
                new DemeanourModel{Description="surly"},
                new DemeanourModel{Description="unkind"},
                new DemeanourModel{Description="unpropitious"},
                new DemeanourModel{Description="unsociable"},
                new DemeanourModel{Description="viperous"},
                new DemeanourModel{Description="virulent"},
                new DemeanourModel{Description="vitriolic"},
                new DemeanourModel{Description="warlike"},
                new DemeanourModel{Description="rancorous"},
                new DemeanourModel{Description="scrappy"},
                new DemeanourModel{Description="disapproving"},
                new DemeanourModel{Description="ill-disposed"},
                new DemeanourModel{Description="oppugnant"},
                new DemeanourModel{Description="unwelcoming"}
            };

            return list;
        }
    }
}
