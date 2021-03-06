using System;
using System.Collections;
using System.Drawing;
using System.IO;
using ImageBase.Common;
using Xunit;

namespace ImageBase.ImageHash.Tests
{
    public class ImageHashServiceUnitTests
    {
        [Fact]
        public void CalculatesForLong()
        {
            var imageHandler = new ImageDCTHashCalculator();
            var imageHashService = new ImageHashService(imageHandler);
            long hashPng;
            long hashJpg;
            long hashJpgSmall;

            using (var pngStream = new FileStream(@"IMG_0.png", FileMode.Open, FileAccess.Read))
            {
                hashPng = imageHashService.CalculateImageHash(pngStream);
            }

            using (var jpgStream = new FileStream(@"IMG_0.jpg", FileMode.Open, FileAccess.Read))
            {
                hashJpg = imageHashService.CalculateImageHash(jpgStream);
            }

            using (var jpgStream = new FileStream(@"IMG_0_small.jpg", FileMode.Open, FileAccess.Read))
            {
                hashJpgSmall = imageHashService.CalculateImageHash(jpgStream);
            }

            Assert.Equal(0, HammingDistance.Calculate(hashPng, hashJpg));
            Assert.Equal(1, HammingDistance.Calculate(hashJpgSmall, hashJpg));
        }

        [Fact]
        public void CalculatesDifferentImagesForLong()
        {
            var imageHandler = new ImageDCTHashCalculator();
            var imageHashService = new ImageHashService(imageHandler);
            long hashJpg;
            long hashJpgOther;

            using (var jpgStream = new FileStream(@"IMG_0.jpg", FileMode.Open, FileAccess.Read))
            {
                hashJpg = imageHashService.CalculateImageHash(jpgStream);
            }

            using (var jpgStream = new FileStream(@"IMG_18.jpg", FileMode.Open, FileAccess.Read))
            {
                hashJpgOther = imageHashService.CalculateImageHash(jpgStream);
            }

            Assert.InRange(HammingDistance.Calculate(hashJpg, hashJpgOther), 10, 100);
        }

        [Fact]
        public void CalculatesForBitArray()
        {
            var imageHandler = new ImageDCTHashCalculator();
            var imageHashService = new ImageHashService(imageHandler);
            var hashPng = new BitArray(64);
            var hashJpg = new BitArray(64);
            var hashJpgSmall = new BitArray(64);

            using (var pngStream = new FileStream(@"IMG_0.png", FileMode.Open, FileAccess.Read))
            {
                imageHashService.CalculateImageHash(pngStream, hashPng);
            }

            using (var jpgStream = new FileStream(@"IMG_0.jpg", FileMode.Open, FileAccess.Read))
            {
                imageHashService.CalculateImageHash(jpgStream, hashJpg);
            }

            using (var jpgStream = new FileStream(@"IMG_0_small.jpg", FileMode.Open, FileAccess.Read))
            {
                imageHashService.CalculateImageHash(jpgStream, hashJpgSmall);
            }

            Assert.Equal(0, HammingDistance.Calculate(hashPng, hashJpg));
            Assert.Equal(1, HammingDistance.Calculate(hashJpgSmall, hashJpg));
        }

        [Fact]
        public void CalculatesDifferentImagesForBitArray()
        {
            var imageHandler = new ImageDCTHashCalculator();
            var imageHashService = new ImageHashService(imageHandler);
            var hashJpg = new BitArray(64);
            var hashJpgOther = new BitArray(64);

            using (var jpgStream = new FileStream(@"IMG_0.jpg", FileMode.Open, FileAccess.Read))
            {
                imageHashService.CalculateImageHash(jpgStream, hashJpg);
            }

            using (var jpgStream = new FileStream(@"IMG_18.jpg", FileMode.Open, FileAccess.Read))
            {
                imageHashService.CalculateImageHash(jpgStream);
            }

            Assert.InRange(HammingDistance.Calculate(hashJpg, hashJpgOther), 10, 100);
        }
    }
}
