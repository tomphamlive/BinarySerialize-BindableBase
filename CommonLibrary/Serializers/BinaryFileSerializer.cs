using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace CommonLibrary.Serializers
{
    public static class BinaryFileSerializer
    {
        private const string FilesFilter = "Files (*.bin)|*.bin|All Files (*.*)|*.*";

        #region Public Methods

        public static string GetOpenFilePathName()
        {
            var openDialog = new OpenFileDialog
            {
                Filter = FilesFilter,
                Title = "Open Binary File"
            };

            return openDialog.ShowDialog() == true ? openDialog.FileName : null;
        }

        public static string GetSaveFilePathName(string initialFileName)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = FilesFilter,
                Title = "Save to Binary File",
                FileName = initialFileName,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            return saveFileDialog.ShowDialog() == true ? saveFileDialog.FileName : null;
        }

        public static void SerializeToFile(string fileName, object objectToSerialize)
        {
            var file = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(file, objectToSerialize);
            }
            catch (SerializationException e)
            {
                var error = "Failed to serialize. Reason: " + e.Message;
                MessageBox.Show(error);
                throw;
            }
            finally
            {
                file.Close();
            }
        }

        public static object DeserializeFromFile(string fileName)
        {
            object result;
            var file = new FileStream(fileName, FileMode.Open);
            try
            {
                var serializer = new BinaryFormatter();
                result = serializer.Deserialize(file);
            }
            catch (SerializationException e)
            {
                var error = "Failed to deserialize. Reason: " + e.Message;
                MessageBox.Show(error);
                throw;
            }
            finally
            {
                file.Close();
            }
            return result;
        }

        #endregion
    }
}
