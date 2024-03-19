using Kindergarden_Models;
using Kindergarden_Services;
using Kindergarden_WForm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;
using Kindergarden_WForm;

namespace Kindergarden_WForm.Business
{
    public class BusinessLogic
    {    
        private readonly KidService kidService;
        private readonly ParentService parentService;
        private readonly GroupService groupService;
        private KindergardenContext db;

        public BusinessLogic(KindergardenContext db)
        {
            this.db = db;
        }

        public void ListAllKids()
        {
        //    List<Kid> kidsList = db.Kids.ToList();
        //    Kid kid;
        //    Parent parent;
        //    Group group;
        //    foreach (var kidTemp in db.Kids)
        //    {
        //        kid = kidTemp;
        //        parent = db.Parents.FirstOrDefault(x => x.ParentId == kid.ParentId);
        //        kid.Parent = parent;
        //        group = db.Groups.FirstOrDefault(y => y.GroupId == kid.GroupId);
        //        kid.Group = group;
        //        dataGridView1.Rows.Add($"{kid.FirstName + " " + kid.LastName}", kid.Age.ToString(),
        //        $"{parent.FirstName + " " + parent.LastName}", parent.PhoneNumber, parent.Address, group.GroupName);
        //    }
        }
        
    }
}
