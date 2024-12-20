using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.SharedData
{
	public static class DataSource
	{
		public static List<Employee> employees = new List<Employee>
		{
			new Employee { Id = Guid.Parse("B39665DB-80DC-4050-BDF9-10033B268E8A"), Code = "EMP001", Name = "Anudeep Arumugham", ContactNo = "9495969701", Address = "Address 1, City 1, State 1", CompanyId = Guid.Parse("683A8508-1123-4C77-84A5-34189BFC66A3") },
			new Employee { Id = Guid.Parse("4AFD4B01-F873-408A-8E18-F61C6BE0D532"), Code = "EMP002", Name = "Cyril David", ContactNo = "9495969702", Address = "Address 2, City 2, State 2", CompanyId = Guid.Parse("683A8508-1123-4C77-84A5-34189BFC66A3") },
			new Employee { Id = Guid.Parse("39051DFA-D6E4-445D-8C6C-FE088005FBD7"), Code = "EMP003", Name = "Sayyed Sadiq", ContactNo = "9495969703", Address = "Address 3, City 3, State 3", CompanyId = Guid.Parse("683A8508-1123-4C77-84A5-34189BFC66A3") },
			new Employee { Id = Guid.Parse("3B19326A-700B-4943-AE18-EF7D15D60F4F"), Code = "EMP004", Name = "Thomas Pallikal", ContactNo = "9495969704", Address = "Address 4, City 4, State 4", CompanyId = Guid.Parse("78B069D7-7025-46B0-A68A-1125DF82BB40") },
			new Employee { Id = Guid.Parse("D540D686-3F10-4E60-95E5-6A1F575F31D7"), Code = "EMP005", Name = "Illyas Ali", ContactNo = "9495969705", Address = "Address 5, City 5, State 5", CompanyId = Guid.Parse("78B069D7-7025-46B0-A68A-1125DF82BB40") },
			new Employee { Id = Guid.Parse("F48EB727-4A5E-47D8-9F9D-7B5C70A02490"), Code = "EMP006", Name = "Vipin Goutham", ContactNo = "9495969706", Address = "Address 6, City 6, State 6", CompanyId = Guid.Parse("78B069D7-7025-46B0-A68A-1125DF82BB40") },
			new Employee { Id = Guid.Parse("00815E7E-B15C-49C8-9E70-1D6BBF853770"), Code = "EMP007", Name = "Amit Padman", ContactNo = "9495969707", Address = "Address 7, City 7, State 7", CompanyId = Guid.Parse("78B069D7-7025-46B0-A68A-1125DF82BB40") },
			new Employee { Id = Guid.Parse("CB35A6FF-CF40-43CD-934C-CFA89EB761DC"), Code = "EMP008", Name = "Yashin Das", ContactNo = "9495969708", Address = "Address 8, City 8, State 8", CompanyId = Guid.Parse("552C7E31-2133-45A0-899B-2E176D692363") },
			new Employee { Id = Guid.Parse("907FC523-4881-4B1A-BEA5-FBE3286E1B7A"), Code = "EMP009", Name = "Ashish Vijayan", ContactNo = "9495969709", Address = "Address 9, City 9, State 9", CompanyId = Guid.Parse("552C7E31-2133-45A0-899B-2E176D692363") },
			new Employee { Id = Guid.Parse("B8831B38-1E6A-4381-B7D9-C0D135829BA4"), Code = "EMP010", Name = "Sreejith Mohandas", ContactNo = "9495969710", Address = "Address 10, City 10, State 10", CompanyId = Guid.Parse("552C7E31-2133-45A0-899B-2E176D692363") },
		};

		public static List<Company> company = new List<Company>
		{
			new Company { Id = Guid.Parse("683A8508-1123-4C77-84A5-34189BFC66A3"), Code = "CPY001", Name = "Company 1", Address = "Street 1, City 1, State 1" },
			new Company { Id = Guid.Parse("78B069D7-7025-46B0-A68A-1125DF82BB40"), Code = "CPY002", Name = "Company 2", Address = "Street 2, City 2, State 2" },
			new Company { Id = Guid.Parse("552C7E31-2133-45A0-899B-2E176D692363"), Code = "CPY003", Name = "Company 3", Address = "Street 3, City 3, State 3" }
		};
	}
}
