using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace Game3
{
    [XmlRoot("Status")]
    public class Status
    {
        [XmlElement("Snowman")]
        public SnowmanStatus SnowmanStatus { get; set; }
        [XmlElement("Kane")]
        public KaneStatus KaneStatus { get; set; }
        [XmlElement("Human")]
        public HumanStatus HumanStatus { get; set; }
        [XmlElement("StrongHuman")]
        public StrongHumanStatus StronghumanStatus { get; set; }
        [XmlElement("Dog")]
        public DogStatus DogStatus { get; set; }
        [XmlElement("StrongDog")]
        public StrongDogStatus StrongDogStatus { get; set; }
        [XmlElement("Kinoko")]
        public KinokoStatus KinokoStatus { get; set; }
        [XmlElement("PoisonKinoko")]
        public PoisonKinokoStatus PoisonKinokoStatus { get; set; }
        [XmlElement("Kirakira")]
        public KirakiraStatus KirakiraStatus { get; set; }
        [XmlElement("Hana")]
        public HanaStatus HanaStatus { get; set; }
        [XmlElement("Wall")]
        public WallStatus WallStatus { get; set; }
        [XmlElement("StrongWall")]
        public StrongWallStatus StrongWallStatus { get; set; }
        [XmlElement("EnemyYellow")]

        public static Status Instance;
        public static void Load()
        {
            var stream = new FileStream("Status.xml", FileMode.Open);
            var serializer = new XmlSerializer(typeof(Status));
            Instance = serializer.Deserialize(stream) as Status;
            stream.Close();
        }
    }

    public class SnowmanStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
    }
    public class KaneStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
        [XmlElement("Income")]
        public int Income { get; set; }
    }
    public class HumanStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
        [XmlElement("Bullet")]
        public int Bullet { get; set; }
    }
    public class StrongHumanStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
        [XmlElement("Bullet")]
        public int Bullet { get; set; }
    }
    public class DogStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
        [XmlElement("Bullet")]
        public int Bullet { get; set; }
        [XmlElement("Range")]
        public int Range { get; set; }
    }
    public class StrongDogStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
        [XmlElement("Bullet")]
        public int Bullet { get; set; }
        [XmlElement("Range")]
        public int Range { get; set; }
    }
    public class KinokoStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
        [XmlElement("Heal")]
        public int Heal { get; set; }
        [XmlElement("Range")]
        public int Range { get; set; }
    }
    public class PoisonKinokoStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
        [XmlElement("Poison")]
        public int Poison { get; set; }
        [XmlElement("Range")]
        public int Range { get; set; }
    }
    public class KirakiraStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
        [XmlElement("Heal")]
        public int Heal { get; set; }
    }
    public class HanaStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
        [XmlElement("Bullet")]
        public int Bullet { get; set; }
    }
    public class WallStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
    }
    public class StrongWallStatus
    {
        [XmlElement("Comment")]
        public string Comment { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Attack")]
        public int Attack { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("Cost")]
        public int Cost { get; set; }
    }
}
