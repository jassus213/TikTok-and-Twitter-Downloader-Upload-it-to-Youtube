﻿using System;
using System.Threading.Tasks;
using Uploader.Core;

namespace Application.Windows.Main.Contracts;

public interface IMainWindowSignalBus
{
    Action<string> SavePathChanged { get; set; }
    Action<UserSecretEntity> UserSecretChanged { get; set; }
}