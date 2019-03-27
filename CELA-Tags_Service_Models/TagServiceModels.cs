using System;
using System.Collections.Generic;

namespace CELA_Tags_Service_Models
{
    public class TopicTag
    {
        public TopicTag()
        {

        }

        public TopicTag(string _name, string _value, string _description)
        {
            name = _name;
            value = _value;
            description = _description;
        }

        public string name { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        public TopicTag parent { get; set; }
        public TopicTag[] subscribers { get; set; }
    }

    class TopicTagUser
    {
        public TopicTagUser()
        {

        }

        public string username { get; set; }
    }

    public class Tag
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        //TODO: This should be a description of known behaviors that will activate when the tag is used
        public string Behavior { get; set; }
        public bool Persistent { get; set; }
        public enum TagType
        {
            action, description, group, matter, organization, project, sensitivity, task, topic
        }

        public TagType Type { get; set; }

        public Tag Parent { get; set; }
        public List<Tag> Children { get; set; }
        public List<Tag> RelatedTags { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether or not to inherit the permissions of a parent tag. Note that the standard behavior respects the parent's inheritance selection, so if a node's parent does not inherit behaviors, neither should the chold nodes.
        /// 
        /// </summary>
        /// <value>
        ///   <c>true</c> if [inherit permissions]; otherwise, <c>false</c>.
        /// </value>
        public bool InheritPermissions { get; set; }

        public List<TagPerson> Owners { get; set; }
        public List<TagPerson> Subscribers { get; set; }
        public List<RetentionPolicy> RetentionPolicies { get; set; }

        public Tag(string name, string value, string description, TagType type, Tag parent, bool inheritPermissions, List<TagPerson> owners, List<TagPerson> subscribers)
        {
            Name = name;
            Value = value;
            Description = description;
            Type = type;
            Persistent = true;
            Parent = parent;
            InheritPermissions = inheritPermissions;

            Owners = new List<TagPerson>();
            if (owners != null)
            {
                foreach (var item in owners)
                {
                    Owners.Add(item);
                }
            }

            Subscribers = new List<TagPerson>();
            if (subscribers != null)
            {
                foreach (var item in subscribers)
                {
                    Subscribers.Add(item);
                }

            }

            Children = new List<Tag>();
        }
    }

    public class TagPerson
    {
        public string ID { get; set; }
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the identifier for the individual user (e.g., alias [jabarnwe]) or group (e.g., groupname [celalawfirmengagement]).
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Identifier { get; set; }
        public enum PersonType
        {
            individual, group
        }

        public PersonType Type { get; set; }

        public TagPerson(string displayName, string identifier, PersonType 
            type)
        {
            DisplayName = displayName;
            Identifier = identifier;
            Type = type;
        }
    }

    public class TagCluster
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public List<TagPerson> Owners { get; set; }
        public List<TagPerson> Subscribers { get; set; }
    }

    /// <summary>
    /// Describes the artifact retention policy that applies to the Tags that subscribe to this RetentionPolicy.
    /// </summary>
    public class RetentionPolicy
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public List<TagPerson> Owners { get; set; }
    }

    //class TagSubscriber: TagPerson
    //{

    //}

    //class TagOwner: TagPerson
    //{

    //}

    public class TagTestDataGenerator
    {
        public TagTestDataGenerator()
        { }

        public List<TagPerson> GenerateIndviduals()
        {
            List<TagPerson> returnList = new List<TagPerson>();
            returnList.Add(new TagPerson("Jason", "Jason", TagPerson.PersonType.individual));
            returnList.Add(new TagPerson("Rebecca", "Rebecca", TagPerson.PersonType.individual));
            returnList.Add(new TagPerson("Tom", "Tom", TagPerson.PersonType.individual));
            return returnList;
        }

        public List<TagPerson> GenerateGroups()
        {
            List<TagPerson> returnList = new List<TagPerson>();
            returnList.Add(new TagPerson("Legal Business", "legalbusiness", TagPerson.PersonType.group));
            returnList.Add(new TagPerson("Legal Operations", "legaloperations", TagPerson.PersonType.group));
            return returnList;
        }

        public static Tag GenerateTagHelper (string tagValue, Tag.TagType type, List<TagPerson> owners, List<TagPerson> subscribers)
        {
            return new Tag(tagValue, tagValue, tagValue, type, null, false, owners, subscribers);
        }

        public static List<TagPerson> GenerateRandomPersonListHelper(List<TagPerson> _listToRandomize)
        {
            List<TagPerson> returnList = new List<TagPerson>();
            foreach (var item in _listToRandomize) 
            {
                //TODO: add randomizer so that not all are added
                returnList.Add(item);
            }
            
            return returnList;
        }

        public List<Tag> GenerateTags(List<TagPerson> owners, List<TagPerson> subscribers)
        {
            List<Tag> returnList = new List<Tag>();

            returnList.Add(GenerateTagHelper("#AttorneyClientPrivileged", Tag.TagType.sensitivity, GenerateRandomPersonListHelper(owners), GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(GenerateTagHelper("#LegalTeamTest", Tag.TagType.topic, GenerateRandomPersonListHelper(owners), GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(GenerateTagHelper("#LegalTeamTask", Tag.TagType.task, GenerateRandomPersonListHelper(owners), GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(GenerateTagHelper("#LegalTeamSyncAgendaItem", Tag.TagType.topic, GenerateRandomPersonListHelper(owners), GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(GenerateTagHelper("#LegalTeamArchiveTest", Tag.TagType.action, GenerateRandomPersonListHelper(owners), GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(GenerateTagHelper("#LegalStrategy", Tag.TagType.topic, GenerateRandomPersonListHelper(owners), GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(GenerateTagHelper("#MID-TESTING", Tag.TagType.matter, GenerateRandomPersonListHelper(owners), GenerateRandomPersonListHelper(subscribers)));
            returnList.Add(GenerateTagHelper("#Tagulous", Tag.TagType.project, GenerateRandomPersonListHelper(owners), GenerateRandomPersonListHelper(subscribers)));

            return returnList;
        }
    }
}
