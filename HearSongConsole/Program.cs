﻿using System;
using System.Collections.Generic;

namespace HearSongConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleContainer = new SimpleTestContainer();
            var scenarioHelper = new ScenarioHelper(
                simpleContainer.UserService,
                simpleContainer.SongService,
                simpleContainer.HearService);
            var scenarioTest = new ScenarioTest(scenarioHelper);

            scenarioTest.Test();
        }

        public static class IoC
        {
            static Dictionary<Type, object> _registeredTypes = new Dictionary<Type, object>();

            public static void Register<T>(T toRegister)
            {
                _registeredTypes.Add(typeof(T), toRegister);
            }

            public static T Resolve<T>()
            {
                return (T)_registeredTypes[typeof(T)];
            }
        }
    }
}
