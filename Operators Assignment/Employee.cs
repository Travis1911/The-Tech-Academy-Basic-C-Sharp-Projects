using System;

namespace OperatorOverloadingAssignment
{
    // Employee class stores employee information.
    public class Employee
    {
        // Employee ID property.
        public int Id { get; set; }

        // Employee first name property.
        public string FirstName { get; set; }

        // Employee last name property.
        public string LastName { get; set; }

        // Overload the == operator to compare Employee objects by Id.
        public static bool operator ==(Employee employee1, Employee employee2)
        {
            // Check if both objects reference the same object.
            if (ReferenceEquals(employee1, employee2))
            {
                return true;
            }

            // Check if either object is null.
            if (employee1 is null || employee2 is null)
            {
                return false;
            }

            // Compare employee IDs.
            return employee1.Id == employee2.Id;
        }

        // Overload the != operator.
        public static bool operator !=(Employee employee1, Employee employee2)
        {
            // Return the opposite result of the == operator.
            return !(employee1 == employee2);
        }

        // Override Equals to maintain consistency with ==.
        public override bool Equals(object obj)
        {
            if (obj is Employee employee)
            {
                return this.Id == employee.Id;
            }

            return false;
        }

        // Override GetHashCode when Equals is overridden.
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}