using System;
using System.Collections.Generic;

namespace StudentManagement
{
    class Student
    {
        // Поля для хранения данных
        private string? name;
        private string? patronymic;
        private string? surname;
        private DateTime birthDate;
        private string? address;
        private string? phone;

        // Поля для хранения оценок
        private LinkedList<int> marks = new LinkedList<int>(); // Зачёты
        private LinkedList<int> courseworks = new LinkedList<int>(); // Курсовые работы
        private LinkedList<int> exams = new LinkedList<int>(); // Экзамены
        private double rating; // Рейтинг

        // Конструктор без параметров
        public Student() : this("Unknown", "Unknown", "Unknown", DateTime.MinValue, "Unknown", "Unknown")
        {
            Console.WriteLine("Constructor without parameters");
        }

        // Конструктор с параметрами: имя, отчество, фамилия
        public Student(string name, string patronymic, string surname) : this(name, patronymic, surname, DateTime.MinValue, "Unknown", "Unknown")
        {
            Console.WriteLine("Constructor with name, patronymic, surname");
        }

        // Конструктор с параметрами: имя, отчество, фамилия, адрес
        public Student(string name, string patronymic, string surname, string address) : this(name, patronymic, surname, DateTime.MinValue, address, "Unknown")
        {
            Console.WriteLine("Constructor with name, patronymic, surname, address");
        }

        // Основной конструктор с параметрами: имя, отчество, фамилия, дата рождения, адрес, телефон
        public Student(string name, string patronymic, string surname, DateTime birthDate, string address, string phone)
        {
            SetName(name);
            SetPatronymic(patronymic);
            SetSurname(surname);
            SetBirthDate(birthDate);
            SetAddress(address);
            SetPhone(phone);
            Console.WriteLine("Main constructor with all parameters");
        }

        // Методы для установки полей
        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetPatronymic(string patronymic)
        {
            this.patronymic = patronymic;
        }

        public void SetSurname(string surname)
        {
            this.surname = surname;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            this.birthDate = birthDate;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void SetPhone(string phone)
        {
            this.phone = phone;
        }

        // Методы для добавления оценок в зачёты, курсовые работы и экзамены
        public void AddMark(int value)
        {
            if (value < 1 || value > 12) return;
            marks.AddLast(value);
            ResetRating();
        }

        public void AddCoursework(int value)
        {
            if (value < 1 || value > 12) return;
            courseworks.AddLast(value);
            ResetRating();
        }

        public void AddExam(int value)
        {
            if (value < 1 || value > 12) return;
            exams.AddLast(value);
            ResetRating();
        }

        // Показ всех данных о студенте
        public void PrintStudent()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Отчество: {patronymic}");
            Console.WriteLine($"Фамилия: {surname}");
            Console.WriteLine($"Дата рождения: {birthDate.ToShortDateString()}");
            Console.WriteLine($"Адрес: {address}");
            Console.WriteLine($"Номер телефона: {phone}");
            Console.Write("Оценки по зачётам: ");
            foreach (var mark in marks)
            {
                Console.Write($"{mark} ");
            }
            Console.WriteLine();
            Console.Write("Оценки по курсовым: ");
            foreach (var coursework in courseworks)
            {
                Console.Write($"{coursework} ");
            }
            Console.WriteLine();
            Console.Write("Оценки по экзаменам: ");
            foreach (var exam in exams)
            {
                Console.Write($"{exam} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Рейтинг оценок: {rating:F1}");
        }

        // Метод для пересчета рейтинга
        private void ResetRating()
        {
            int totalGradesCount = marks.Count + courseworks.Count + exams.Count;

            if (totalGradesCount == 0)
            {
                rating = 0;
                return;
            }

            int totalSum = CalculateSum(marks) + CalculateSum(courseworks) + CalculateSum(exams);
            rating = (double)totalSum / totalGradesCount;
        }

        // Метод для вычисления суммы значений
        private int CalculateSum(LinkedList<int> list)
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Пример создания студента со всеми параметрами
            Student student = new Student("Василий", "Алибабаевич", "Пупкин", new DateTime(1995, 02, 06), "ул. Литературная, д. 18", "+380955289873");
            student.AddMark(12);
            student.AddMark(10);
            student.AddMark(11);
            student.AddCoursework(12);
            student.AddExam(12);
            student.PrintStudent();
            Console.WriteLine();
        }
    }
}
