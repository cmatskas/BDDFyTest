using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.BDDfy;
using Xunit;

namespace BDDFyTest
{
    public class RandomServiceTests
    {
        private int iterationsToTest;
        private bool shouldRun;
        private RandomService testTarget;

        [Fact]
        public void RandomServiceTaskWillRun()
        {
            this.Given(x => x.GivenMoreThanOneIterations())
                .When(x => x.AndTaskSetToRun())
                .Then(x => x.ThenTheClassShouldInitializeCorrectly())
                .And(x => x.AndTaskShouldRun())
                .BDDfy("Results 0");

        }

        [Fact]
        public void RandomServiceTaskWillRunOnce()
        {
            var result = this.Given(x => x.GivenOneIterationOnly())
                .When(x => x.AndTaskSetToRun())
                .Then(x => x.ThenTheClassShouldInitializeCorrectly())
                .And(x => x.AndTaskShouldRun())
                .BDDfy("Results 1");
        }

        [Fact]
        public void RandomServiceTaskWillNotRunWhenIterationsAreLessThanOne()
        {
            this.Given(x => x.GivenNoIterations())
                .When(x => x.AndTaskSetToRun())
                .Then(x => x.ThenTheClassShouldInitializeCorrectly())
                .And(x => x.AndTaskShouldNotRun())
                .BDDfy("Results 2");
        }

        [Fact]
        public void RandomServiceTaskWillNotRunWhenShouldRunSetToFalse()
        {
            this.Given(x => x.GivenMoreThanOneIterations())
                .When(x => x.AddTaskIsSetToNotRun())
                .Then(x => x.ThenTheClassShouldInitializeCorrectly())
                .And(x => x.AndTaskShouldNotRun())
                .BDDfy("Results 3");
        }

        private void GivenMoreThanOneIterations()
        {
            iterationsToTest = 3;
        }

        private void GivenOneIterationOnly()
        {
            iterationsToTest = 1;
        }

        private void GivenNoIterations()
        {
            iterationsToTest = 0;
        }

        private void AndTaskSetToRun()
        {
            shouldRun = true;
        }

        private void AddTaskIsSetToNotRun()
        {
            shouldRun = false;
        }

        private void ThenTheClassShouldInitializeCorrectly()
        {
            testTarget = new RandomService(iterationsToTest, shouldRun);
            Assert.NotNull(testTarget);
        }

        private void AndTaskShouldRun()
        {
            var result = testTarget.PrintMessage("hello world");
            Assert.True(result);
        }

        private void AndTaskShouldNotRun()
        {
            var result = testTarget.PrintMessage("hello world");
            Assert.False(result);
        }
    }
}
