using System;

namespace PeopleLibrary.Models
{
    [Serializable]
    public class MaleStudent : Student
    {
        #region Static Fields

        public const string ImagePath = "EquipmentImages/PI Product Stream.png";

        public static int MaleIdCount;

        #endregion

        #region Constructor

        public MaleStudent()
        {
            Id = ++MaleIdCount;
        }

        #endregion
    }
}
