using PlanITpoker;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace IPlanItPokerApi.Specs
{
    [Binding]
    public class PlanItPokerApiSteps
    {
        private LoginData login;
        private Room room;
        private object _response;
        private string _message;
        private object _statusCode;
        private HttpClient client;

        public PlanItPokerApiSteps()
        {
            login = new LoginData();
            room = new Room();
            var baseAddress = new Uri("https://planitpoker.com/");
            // Set your cookies up in the cookie container of an HttpClientHandler
            var handler = new HttpClientHandler();
            handler.CookieContainer.Add(baseAddress, new Cookie("C", "is for cookie"));

            // Use that to create a new HttpClient with the same base address
            client = new HttpClient(handler) { BaseAddress = baseAddress };

        }

        [Given(@"the first input is ""(.*)""")]
        public void GivenTheFirstInputIs(string email)
        {
            login.email = email;
        }
        
        [Given(@"the second input is ""(.*)""")]
        public void GivenTheSecondInputIs(string password)
        {
            login.password = password;
        }
        
        [When(@"making a post request")]
        public async System.Threading.Tasks.Task WhenMakinAPostRequestAsync()
        {
            var api = RestService.For<IPlanItApi>(client);
            try
            {
                _response = await api.Login(login);
            }
            catch(ApiException exception)
            {
                _statusCode = exception.StatusCode;
                _message = exception.Message;
            }           
        }
        
        [Then(@"the status code should be ""(.*)""")]
        public void ThenTheStatusCodeShouldBe(string statusCode)
        {
            if (_response != null)
            {
                _response.Equals(statusCode);
            }
            else
            {
                _statusCode.Equals(statusCode);
            }
        }

        [Then(@"the message should be ""(.*)""")]
        public void ThenThemMessageShouldBe(string message)
        {
            _message.Equals(message);
        }

        [Given(@"the name is ""(.*)""")]
        public void GivenTheNameIs(string name)
        {
            room.name = name;
        }

        [Given(@"the cardSetType is (.*)")]
        public void GivenTheCardSetTypeIs(int cardSetType)
        {
            room.cardSetType = cardSetType;
        }
        [Given(@"the haveStories is (.*)")]
        public void GivenTheHaveStoriesIs(bool haveStories)
        {
            room.haveStories = haveStories;
        }

        [Given(@"the confirmSkip is (.*)")]
        public void GivenTheConfirmSkipIs(bool confirmSkip)
        {
            room.confirmSkip = confirmSkip;
        }
        [Given(@"the showVotingToObservers is (.*)")]
        public void GivenTheShowVotingToObserversIs(bool showVotingToObservers)
        {
            room.showVotingToObservers = showVotingToObservers;
        }

        [Given(@"the autoReveal is (.*)")]
        public void GivenTheAutoRevealIs(bool autoReveal)
        {
            room.autoReveal = autoReveal;
        }
        [Given(@"the changeVote is (.*)")]
        public void GivenTheChangeVoteIs(bool changeVote)
        {
            room.changeVote = changeVote;
        }

        [Given(@"the countdownTimer is (.*)")]
        public void GivenTheCountdownTimerIs(bool countdownTimer)
        {
            room.countdownTimer = countdownTimer;
        }

        [Given(@"the countdownTimerValue is (.*)")]
        public void GivenTheCountdownTimerValueIs(int countdownTimerValue)
        {
            room.countdownTimerValue = countdownTimerValue;
        }

    }
}
