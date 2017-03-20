﻿namespace Blog.Dto
{
    using System;

    public class BlogFileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Url { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
