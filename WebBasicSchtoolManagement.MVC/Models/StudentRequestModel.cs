namespace WebBasicSchtoolManagement.MVC.Models
{
	public class StudentRequestModel
	{
		public string StdId { get; set; } = null!;

		public string StdName { get; set; } = null!;

		public string? FatherName { get; set; }

		public int StdAge { get; set; }

		public DateOnly Dob { get; set; }

		public string Gender { get; set; } = null!;

		public DateOnly ResgisterDate { get; set; }
	}
}
