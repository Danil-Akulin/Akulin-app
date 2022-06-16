using System;
using System.Drawing;
using SQLite;

namespace tthk_graz_app
{
    public class Contact
    {
        static readonly Color[] materialColors = new Color[]
        {
            Color.DarkOrange,
            Color.Tomato,
            Color.DarkMagenta,
            Color.DeepSkyBlue,
            Color.DeepPink,
            Color.DarkGreen,
            Color.YellowGreen,
            Color.DarkTurquoise,
            Color.SeaGreen,
            Color.DarkOrchid,
            Color.DarkViolet,
            Color.DarkSalmon,
            Color.RoyalBlue,
            Color.Goldenrod,
            Color.DodgerBlue,
            Color.MediumVioletRed
        };

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Twitter { get; set; }
        public string Telegram { get; set; }
        public string VK { get; set; }
        public string Email { get; set; }
        public string Initials => FirstName[0].ToString() + LastName[0].ToString();

        public Color CircleColor
        {
            get
            {
                Random random = new Random();
                return materialColors[random.Next(materialColors.Length)];
            }
        }
    }
}