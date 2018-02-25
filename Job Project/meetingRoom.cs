using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Project
{
    public class meetingRoom : IEquatable<meetingRoom>
    {
        bool computer;
        int classNumber;
        int capacity;
        bool internetConnection;
        bool TvWebcam;

        public bool Computer
        {
            get
            {
                return computer;
            }

            set
            {
                computer = value;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }

            set
            {
                capacity = value;
            }
        }

        public bool InternetConection
        {
            get
            {
                return internetConnection;
            }

            set
            {
                internetConnection = value;
            }
        }

        public bool TvWebcam1
        {
            get
            {
                return TvWebcam;
            }

            set
            {
                TvWebcam = value;
            }
        }

        public int ClassNumber
        {
            get
            {
                return classNumber;
            }

            set
            {
                classNumber = value;
            }
        }

        public bool Equals(meetingRoom other)
        {
            if (other == null) return false;
            return (this.computer.Equals(other.computer));
        }
    }
}
