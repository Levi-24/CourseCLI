﻿namespace CourseCLI
{
    internal class Course
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public bool Gender { get; set; }
        public int Money { get; set; }
        public int[] Results { get; set; }

        public Course(string dataRow)
        {
            var pieces = dataRow.Split(';');
            FirstName = pieces[0].Split(' ')[0];
            FamilyName = pieces[0].Split(' ')[1];
            Gender = pieces[1] == "m" ? true : false;
            Money = int.Parse(pieces[2]);
            Results = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Results[i] = int.Parse(pieces[i+3]);
            }
        }

        public override string ToString()
        {
            return $"Name: {FirstName + ' ' + FamilyName}, Gender: {Gender}, Money: {Money}, Results: {Results};";
        }
    }
}
