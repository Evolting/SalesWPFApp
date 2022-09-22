using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessObject;
using DataAccess.Entity;
using DataAccess.Repository;

namespace SalesWPFApp.ViewModel
{
    public class MemberViewModel
    {
        IMemberRepository memberRepository = new MemberRepository();

        private readonly ObservableCollection<MemberObject> _members;

        public ObservableCollection<MemberObject> Members => _members;

        public MemberViewModel()
        {
            List<Member> memberList = (List<Member>) memberRepository.GetMembers();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            this._members = new ObservableCollection<MemberObject>(memberList.Select(mem => mapper.Map<Member, MemberObject>(mem)));
        }
    }
}
