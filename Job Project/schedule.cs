using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Project
{
    class schedule
    {
        int classNumber;
        DateTime inicialTimeMeeting;
        DateTime finishTimeMeeting;

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

        public DateTime InicialTimeMeeting
        {
            get
            {
                return inicialTimeMeeting;
            }

            set
            {
                inicialTimeMeeting = value;
            }
        }

        public DateTime FinishTimeMeeting
        {
            get
            {
                return finishTimeMeeting;
            }

            set
            {
                finishTimeMeeting = value;
            }
        }
    }
}
