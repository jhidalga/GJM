﻿namespace GJM.Data
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.MinValue;
    }
}
