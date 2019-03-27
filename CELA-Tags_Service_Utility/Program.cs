using System;
using System.Collections.Generic;
using CELA_Tags_Service_Models;
using Newtonsoft.Json;

namespace CELA_Tags_Service_Utility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Writing Tag Data");
            var utility = new Utility();
            var people = utility.generateIndviduals();
            var tags = utility.generateTagTestData(people, people);
            string output = JsonConvert.SerializeObject(tags);
            System.IO.File.WriteAllText("output.json", output);
            Console.ReadLine();
        }
    }

    public class Utility
    {
        public Utility()
        {

        }

        public List<TagPerson> generateIndviduals()
        {
            List<TagPerson> returnList = new List<TagPerson>();
            returnList.Add(new TagPerson("Jason Barnwell", "jabarnwe", TagPerson.PersonType.individual));
            returnList.Add(new TagPerson("Rebecca Benavides", "rebenavi", TagPerson.PersonType.individual));
            returnList.Add(new TagPerson("Tom Orrison", "torrison", TagPerson.PersonType.individual));
            return returnList;
        }

        public List<TagPerson> generateGroups()
        {
            List<TagPerson> returnList = new List<TagPerson>();
            returnList.Add(new TagPerson("Law Firm Engagement", "celalawfirmengagement", TagPerson.PersonType.group));
            returnList.Add(new TagPerson("Office of the President", "oop", TagPerson.PersonType.group));
            return returnList;
        }

        public List<Tag> generateTagTestData(List<TagPerson> owners, List<TagPerson> subscribers)
        {
            List<Tag> returnList = new List<Tag>();

            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#AttorneyClientPrivileged", Tag.TagType.topic, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamTest", Tag.TagType.topic, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamTask", Tag.TagType.task, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamSyncAgendaItem", Tag.TagType.topic, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveRelationshipPartners", Tag.TagType.group, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveAffinityNetwork", Tag.TagType.group, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveDiversity", Tag.TagType.topic, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveEngagementLeads", Tag.TagType.group, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveArentFox", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveCisco", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveCMS", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveDechert", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveDWT", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveEversheds", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveEY", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveFish", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveGreenberg", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveKLGates", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveLatham", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveMerchant", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveOrrick", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchivePaulWeiss", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchivePerkins", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveSidley", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveSimpson", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveTest", Tag.TagType.action, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalTeamArchiveCLOC2018SPPPresentation", Tag.TagType.project, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#OOPGroup", Tag.TagType.organization, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#OOPLeads", Tag.TagType.group, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LearningClique", Tag.TagType.group, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#CELANewManagers", Tag.TagType.group, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LCLDPNW", Tag.TagType.group, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LCLDNewsDesk", Tag.TagType.group, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(TagTestDataGenerator.GenerateTagHelper("#LegalStrategy", Tag.TagType.topic, TagTestDataGenerator.GenerateRandomPersonListHelper(owners), TagTestDataGenerator.GenerateRandomPersonListHelper(subscribers)));

            return returnList;
        }
    }
}