using System;
using System.Collections.Generic;
using System.Text;

namespace class05_students_app.models
{
    class Students
    {
        private string id;
        private string name;
        private string age;
        private string address;
        private string carrier;
        private string semester;
        public void SetAll(string[] values)
        {
            this.id = values[0];
            this.name = values[1];
            this.age = values[2];
            this.address = values[3];
            this.semester = values[4];
            this.carrier = values[5];
        }
        public void SetId(string id)
        {
            this.id = id;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAge(string age)
        {
            this.age = age;
        }
        public void SetAddress(string address)
        {
            this.address=address;
        }
        public void SetSemester(string semester)
        {
            this.semester = semester;
        }
        public void SetCarrier(string carrier)
        {
            this.carrier = carrier;
        }
        public string GetLine()
        {
            return id + "," + name + "," + age + "," + address + "," + semester + "," + carrier;
        }
        public string GetId() { return id; }
        public string GetName() { return name; }
        public string GetAge() { return age; }
        public string GetAddress() { return address; }
        public string GetSemester() { return semester; }
        public string GetCarrier() { return carrier; }

    }
}
