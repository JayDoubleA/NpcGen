using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using NpcGen.DataAccess;
using NpcGen.Models.NpcModels;
using NpcGen.Extensions;

namespace NpcGen.ControllerHelpers
{
    public class ImportHelper
    {
        private readonly NpcContext _context = new NpcContext();
        private TextFieldParser _csvReader;
        public string Csv { get; set; }

        public string Report { get; set; }

        public ImportHelper()
        {

        }

        public ImportHelper(string csv)
        {
            Csv = csv;
        }

        public void Init()
        {
            // convert string to stream
            var byteArray = Encoding.UTF8.GetBytes(Csv);
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            var stream = new MemoryStream(byteArray);

            _csvReader = new TextFieldParser(stream)
            {
                TextFieldType = FieldType.Delimited
            };
            _csvReader.SetDelimiters(new[] { "," });
            _csvReader.HasFieldsEnclosedInQuotes = true;
        }

        public void ClassAbilityImport()
        {
            var list = ClassAbilitiesFromCsvGet();

            foreach (var cls in list)
            {
                _context.ClassAbilities.AddOrUpdate(r => r.Name, cls);
            }

            _context.SaveChanges();
        }

        public List<ClassAbilityModel> ClassAbilitiesFromCsvGet()
        {
            var list = new List<ClassAbilityModel>();
            Init();

            while (!_csvReader.EndOfData)
            {
                try
                {
                    var row = _csvReader.ReadFields();

                    if (row != null && row.Length > 1)
                    {
                        var ab = new ClassAbilityModel { Name = row[0], Description = row[1] };
                        list.Add(ab);
                        Report += string.Format("Imported {0}<br />", row[0]);
                    }
                    else
                    {
                        Report += "Bad row skipped...<br />";
                    }
                }
                catch
                    (Exception ex)
                {
                    Report += string.Format("Error importing {0}<br />", ex.Message);
                }
            }

            return list;
        }

        public void ClassesImport()
        {
            var classes = ClassesFromCsvGet();

            foreach (var cls in classes)
            {
                _context.Classes.AddOrUpdate(r => r.Name, cls);
            }

            _context.SaveChanges();
        }

        public List<ClassModel> ClassesFromCsvGet()
        {
            var list = new List<ClassModel>();

            //Init();

            //while (!_csvReader.EndOfData)
            //{
            //    try
            //    {
            //        var row = _csvReader.ReadFields();

            //        if (row != null && row.Length > 18)
            //        {
            //            var testName = row[5];
            //            var magic = _context.Magics.FirstOrDefault(m => m.MagicName == testName) ??
            //                        new MagicModel { MagicName = "None" };

            //            var attacks = AttackStringParse(row[4]);
            //            if (attacks.Count > 0)
            //            {
            //                foreach (var attack in attacks)
            //                {
            //                    _context.Attacks.AddOrUpdate(a => a.Name, attack);
            //                }

            //                _context.SaveChanges();
            //            }

            //            var cls = new ClassModel();
            //            cls.Name = row[0];
            //            cls.HitDieType = int.Parse(row[1]);
            //            cls.Level = int.Parse(row[2]);
            //            cls.ProficencyBonus = int.Parse(row[3]);
            //            cls.Attacks = AttacksRecover(attacks);
            //            cls.Magic = magic;
            //            cls.Strength = int.Parse(row[6]);
            //            cls.Dexterity = int.Parse(row[7]);
            //            cls.Constitution = int.Parse(row[8]);
            //            cls.Intelligence = int.Parse(row[9]);
            //            cls.Wisdom = int.Parse(row[10]);
            //            cls.Charisma = int.Parse(row[11]);
            //            cls.HitPoints = int.Parse(row[12]);
            //            cls.Movement = int.Parse(row[13]);
            //            cls.BaseArmourClass = int.Parse(row[14]);
            //            cls.Proficiencies = ProfsGet(row[15]);
            //            cls.Expertises = ProfsGet(row[16]);
            //            cls.ClassAbilities = AbilitiesGet(row[17]);
            //            cls.Possessions = row[18];
            //            list.Add(cls);
            //            Report += string.Format("Imported {0}<br />", row[0]);
            //        }
            //        else
            //        {
            //            Report += "Bad row skipped...<br />";
            //        }
            //    }
            //    catch
            //        (Exception ex)
            //    {
            //        Report += string.Format("Error importing: {0}<br />", ex.Message);
            //    }
            //}
            return list;
        }

        private List<AttackModel> AttackStringParse(string attackString)
        {
            var list = new List<AttackModel>();
            //try
            //{

            //    var attackArr = attackString.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            //    foreach (var at in attackArr)
            //    {
            //        var atArr = at.Split(new[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            //        var attack = new AttackModel
            //        {
            //            Name = atArr[0],
            //            ToHit = int.Parse(atArr[1]),
            //            Damage = atArr[2]
            //        };

            //        if (atArr.Length > 3)
            //        {
            //            // figure out if the next value is range or special...
            //            int range;
            //            if (int.TryParse(atArr[3], out range))
            //            {
            //                attack.Range = range;
            //            }
            //            else
            //            {
            //                attack.Special = atArr[3];
            //            }
            //        }

            //        if (atArr.Length > 4)
            //        {
            //            // if this exists, it will always be the special
            //            attack.Special = atArr[4];
            //        }

            //        list.Add(attack);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return list;
        }

        private List<AttackModel> AttacksRecover(IEnumerable<AttackModel> root)
        {
            var contAt = _context.Attacks;
            var list = new List<AttackModel>();

            foreach (var at in root)
            {
                list.Add(contAt.FirstOrDefault(x => x.Name.Equals(at.Name)));
            }

            return list;
        }

        private List<ProficiencyModel> ProfsGet(string profstring)
        {
            var profsDb = _context.Proficiencies.ToList();
            var profsArr = profstring.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                return
                    profsArr.Select(profTest => profsDb.First(x => x.Name.EqualsCaseInsensitive(profTest)))
                        .Where(prof => prof != null)
                        .ToList();
            }
            catch
            {
                return new List<ProficiencyModel>();
            }
        }

        private List<ClassAbilityModel> AbilitiesGet(string abstring)
        {
            var absDb = _context.ClassAbilities.ToList();
            var absArr = abstring.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            return absArr.Select(abTest => absDb.FirstOrDefault(x => x.Name.EqualsCaseInsensitive(abTest))).Where(ab => ab != null).ToList();
        }
    }
}