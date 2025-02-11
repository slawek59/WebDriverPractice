﻿namespace WebDriverPractice.Business.Models
{
	public class UserModel
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Username { get; set; }
		public string? Email { get; set; }
		public AddressModel? Address { get; set; }
		public string? Phone { get; set; }
		public string? Website { get; set; }
		public UserModel? Company { get; set; }
	}
}
