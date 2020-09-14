﻿using HMS.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HMS.Interface
{
    public interface StudentLeaveRequestI
    {
        Task ServiceFaild(string result);

        Task GetAllLeaveType(ObservableCollection<LeaveTypeModel> leaveTypes);

        Task SaveLeaveRequest(String result);
    }
}
