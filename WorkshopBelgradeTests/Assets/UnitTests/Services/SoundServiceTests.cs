using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets;
using Assets.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkshopBelgradeTests.Assets.UnitTests.Services
{
    [TestClass]
    public class SoundServiceTests
    {
        [TestMethod]
        public void GivenSoundServiceWithoutAudioSource_WhenPlaySound_ThenExceptionThrown()
        {
            try
            {
                // Given
                var soundService = new SoundService();

                // When
                soundService.PlaySound();

            }

            // Then
            catch (Exception e)
            {
                Assert.AreEqual("Audio source not set.", e.Message);
            }
        }
    }
}
