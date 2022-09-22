using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(Member member) => MemberManagement.Instance.Remove(member);

        public Member GetMemberByID(int memberID) => MemberManagement.Instance.GetMemberByID(memberID);

        public IEnumerable<Member> GetMembers() => MemberManagement.Instance.GetMemberList();

        public void InsertMember(Member member) => MemberManagement.Instance.AddNew(member);

        public void UpdateMember(Member member) => MemberManagement.Instance.Update(member);
    }
}
