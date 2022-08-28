using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectPolicies.Models
{
    public class PerfectPoliciesContext : DbContext
    {
        public PerfectPoliciesContext(DbContextOptions options) : base(options){}
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<UserInfo> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserInfo>().HasData(
                new UserInfo
                {
                    UserInfoId = 1,
                    UserName = "AdminPerfectPolicies",
                    Password = "PerfectPolicies!22"
                },

                new UserInfo
                {
                    UserInfoId = 2,
                    UserName = "Yang",
                    Password = "abc_1234"
                });



            builder.Entity<Quiz>().HasData(
                new Quiz
                {
                    QuizId = 1,
                    QuizTitle = "Steve's Warehouse Policy Quiz",
                    QuizTopic = "Working at Heights",
                    QuizCreatorName = "Steve Jones from Steve's Warehouse",
                    QuizCreatedDate = new DateTime(20 / 11 / 2021),
                    PassPercentage = 100
                },

                new Quiz
                {
                    QuizId = 2,
                    QuizTitle = "Steve's Warehouse Policy Quiz",
                    QuizTopic = "Copyright",
                    QuizCreatorName = "Steve Jones from Steve's Warehouse",
                    QuizCreatedDate = new DateTime(20 / 11 / 2021),
                    PassPercentage = 100
                },

                new Quiz
                {
                    QuizId = 3,
                    QuizTitle = "How well do you know Australia?",
                    QuizTopic = "Geography",
                    QuizCreatorName = "Yang Xiang",
                    QuizCreatedDate = new DateTime(23 / 02 / 2022),
                    PassPercentage = 100
                });

            builder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    QuestionTopic = "Working at Heights",
                    QuestionText = "When looking to work at heights, I need to review:",
                    QuestionImageUrl = null,
                    QuizId = 1
                },

                new Question
                {
                    QuestionId = 2,
                    QuestionTopic = "Copyright",
                    QuestionText = "With copyright material form our client:",
                    QuestionImageUrl = null,
                    QuizId = 2
                },

                new Question
                {
                    QuestionId = 3,
                    QuestionTopic = "Geography",
                    QuestionText = "The capital of Australia is::",
                    QuestionImageUrl = null,
                    QuizId = 3
                });

            builder.Entity<Option>().HasData(
                new Option
                {
                    OptionId = 1,
                    OptionText = "Canberra",
                    OptionLetter = "a. ",
                    OptionIsCorrect = true,
                    QuestionId = 3
                },
                new Option
                {
                    OptionId = 2,
                    OptionText = "Brisbane",
                    OptionLetter = "b. ",
                    OptionIsCorrect = false,
                    QuestionId = 3
                },

                new Option
                {
                    OptionId = 3,
                    OptionText = "Sydney",
                    OptionLetter = "c. ",
                    OptionIsCorrect = false,
                    QuestionId = 3
                },

                new Option
                {
                    OptionId = 4,
                    OptionText = "Melbourne",
                    OptionLetter = "d. ",
                    OptionIsCorrect = false,
                    QuestionId = 3

                });
        }
    }
}
