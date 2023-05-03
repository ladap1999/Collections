﻿using TreeCollection.TestModels.Enums;

namespace TreeCollection.TestModels.Models
{
    public class ExamResult : IComparable<ExamResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exams Exam { get; set; }
        public Score Score { get; set; }
        public DateTime Date { get; set; }

        public ExamResult(int id, string name, Exams exam, Score score, DateTime date)
        {
            Id = id;
            Name = name;
            Exam = exam;
            Score = score;
            Date = date;
        }

        public int CompareTo(ExamResult? obj)
        {
            int result = this.Name.CompareTo(obj.Name);
            if (result == 0)
            {
                result = this.Date.CompareTo(obj.Date);
            }

            if (result == 0)
            {
                result = this.Id.CompareTo(obj.Id);
            }

            return result;
        }
    }
}
