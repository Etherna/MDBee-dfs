﻿//   Copyright 2021 Etherna Sagl
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Etherna.HackathonDemo
{
    class SplashPlayer
    {
        public static async Task PlayAsync(int playTime, int stopTime)
        {
            /* Using try/catch for avoid a crash if frame files are not found. */
            try
            {
                // Load frames.
                var frameFiles = Directory.GetFiles(@"Resources\Splash");
                var frames = frameFiles.Select(ff => File.ReadLines(ff));

                // Draw frames.
                var timePerFrame = playTime / frames.Count();
                Console.Clear();
                foreach (var frame in frames)
                {
                    Console.CursorTop = 0;
                    Console.CursorLeft = 0;
                    foreach (var line in frame)
                    {
                        Console.CursorTop++;
                        Console.CursorLeft = 0;

                        Console.Write(line);
                    }

                    await Task.Delay(timePerFrame);
                }

                // Pause.
                await Task.Delay(stopTime);
            }
            catch { }
        }
    }
}
