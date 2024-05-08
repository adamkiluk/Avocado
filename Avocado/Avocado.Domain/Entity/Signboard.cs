namespace Avocado.Domain.Entity
{
    using System;
    using System.Collections.Generic;

    public class Signboard
    {
        public Guid SignboardId { get; set; }
        public Guid UserId { get; set; }
        public Guid? CompanyId{ get; set; }

        public virtual User User { get; set; }
        public virtual Company Company{ get; set; }

        public string CompanyName { get; set; }
        public string Title { get; set; }
        public List<string> SeniorityLevel { get; set; }
        public string About { get; set; }
        public bool HiddenRange { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public List<string> MustHave { get; set; }
        public List<string> NiceToHave { get; set; }
        public List<string>  DailyTasks { get; set; }

    }
}       
