using System;

namespace CELA_Tags_Service_Model_Library
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
}
