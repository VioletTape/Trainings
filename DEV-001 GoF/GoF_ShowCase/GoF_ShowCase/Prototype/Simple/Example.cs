using System;
using System.Collections.Generic;

namespace GoF_ShowCase.Prototype.Simple {
    public class Example {
        /*
          Использовать операцию new для создания новых объектов невозможно, 
          т.к. неизвестен их конкретный тип. 
          Применение шаблона Прототип легко решает эту проблему:
        */
        public void InsertCopy(IEnumerable<SchemeElement> selectedElements) {
            foreach (var element in selectedElements) {
                var newElement = element.Clone();

                // The Id must be unique
                newElement.Id = GetNewId();

                // TODO: Setup the new element

                // Add the element to the scheme
                AddNewElement(newElement);
            }
        }

        private void AddNewElement(SchemeElement newElement) {
            throw new NotImplementedException();
        }

        private uint GetNewId() {
            throw new System.NotImplementedException();
        }
    }
}