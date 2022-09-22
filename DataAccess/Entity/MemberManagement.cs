using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class MemberManagement
    {
        //---------------------------------------------------
        // Using Singleton Pattern
        private static MemberManagement instance = null;
        private static readonly object instanceLock = new object();
        private MemberManagement() { }
        public static MemberManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberManagement();
                    }
                    return instance;
                }
            }
        }

        //---------------------------------------------------
        public IEnumerable<Member> GetMemberList()
        {
            List<Member> members;
            try
            {
                var context = new SalesManagementSystemContext();
                members = context.Members.ToList();

                Console.WriteLine(members.Count);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return members;
        }
        //---------------------------------------------------
        public Member GetMemberByID(int memberId)
        {
            Member member = null;
            try
            {
                var context = new SalesManagementSystemContext();
                member = context.Members.SingleOrDefault(member => member.MemberId == memberId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return member;
        }
        //---------------------------------------------------
        public void AddNew(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if (_member == null)
                {
                    var context = new SalesManagementSystemContext();
                    context.Members.Add(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //---------------------------------------------------
        public void Update(Member member)
        {
            try
            {
                Member c = GetMemberByID(member.MemberId);
                if (c != null)
                {
                    var context = new SalesManagementSystemContext();
                    context.Entry<Member>(member).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member doesn't exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //---------------------------------------------------
        public void Remove(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if (_member != null)
                {
                    var context = new SalesManagementSystemContext();
                    context.Members.Remove(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member doesn't exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
