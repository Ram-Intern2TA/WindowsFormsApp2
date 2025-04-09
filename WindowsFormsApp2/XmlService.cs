using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace WindowsFormsApp2
{
    public class XmlService
    {
        public void AddToCategoryXml(XmlDocument PlatCategoryXml,string Filepath,string newCategoryId,string newItem)
        {
            try
            {



                //Add category and item in category xml
                var _PlatCategory = PlatCategoryXml;

                XmlElement root = _PlatCategory.DocumentElement;

                XmlNode existingCategory = _PlatCategory.SelectSingleNode($"Categories/Category[@Id = '{newCategoryId}']");

                if (existingCategory != null)
                {
                    MessageBox.Show("Category already exists");
                    return;
                }

                XmlElement newCategory = _PlatCategory.CreateElement("Category");
                newCategory.SetAttribute("Id", newCategoryId);

                if (string.IsNullOrEmpty(newItem))
                {
                    MessageBox.Show("Please Enter the Item name");
                    return;
                }
                XmlNode existingItem = _PlatCategory.SelectSingleNode($"Categories/Category/Item[text() = '{newItem}']");

                if (existingItem != null)
                {
                    MessageBox.Show("Item already exists");
                    return;
                }



                XmlElement newItemElement = _PlatCategory.CreateElement("Item");
                newItemElement.InnerText = newItem;
                newCategory.AppendChild(newItemElement);

                root.AppendChild(newCategory);

                _PlatCategory.Save(Filepath);

                MessageBox.Show($"New Category:{newCategoryId} and New Invoice Item {newItem} added successfully ");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while trying to save new Category due to {ex.Message}");
                return;
            }


        }

        public void AddToMappingXml(XmlDocument QbMappingsXml, string filepath, string _qbMapping_comboBox, string newCategoryId)
        {
            try
            {
             
                    
                    XmlNode ExistingMapping = QbMappingsXml.SelectSingleNode($"AccountMappings/Account[@Id = '{_qbMapping_comboBox}']");

                    XmlElement newCategory = QbMappingsXml.CreateElement("Category");
                    newCategory.InnerText = newCategoryId;
                    ExistingMapping.AppendChild(newCategory);

                    QbMappingsXml.Save(filepath);
                    return;

                
            }



            catch (Exception ex)
            {
                MessageBox.Show($"Error while adding Category to QB Account Mapping due to {ex.Message}");
                return;

            }

        }
    }
}
