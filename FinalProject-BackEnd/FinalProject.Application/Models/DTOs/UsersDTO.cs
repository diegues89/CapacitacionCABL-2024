﻿namespace FinalProject.Applications.Models.DTOs
{
    public class UsersDTO
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int CUIT { get; set; }
        //public int rolId { get; set; }
        public string? RoleName { get; set; }
    }
}
