using System;

namespace PeopleLibrary.Models
{
    [Serializable]
    public class FemaleStudent : Student
    {
        #region Static Fields 

        public const string ImagePath = "EquipmentImages/PI Feed Stream.png";

        public static int FemaleIdCount;

        #endregion

        #region Constructor

        public FemaleStudent()
        {
            Id = ++FemaleIdCount;
        }

        #endregion
    }
}
