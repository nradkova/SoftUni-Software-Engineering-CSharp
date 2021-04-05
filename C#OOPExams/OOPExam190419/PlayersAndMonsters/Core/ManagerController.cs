namespace PlayersAndMonsters.Core
{
    using Contracts;
    using System.Text;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly ICardFactory cardFactory;
        private readonly IPlayerFactory playerFactory;
        private readonly IPlayerRepository playerRepository;
        private readonly ICardRepository cardRepository;
        private readonly IBattleField battleField;

        public ManagerController()
        {
            cardFactory = new CardFactory();
            playerFactory = new PlayerFactory();
            playerRepository = new PlayerRepository();
            cardRepository = new CardRepository();
            battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
           IPlayer player= playerFactory.CreatePlayer(type, username);
            playerRepository.Add(player);
            return string.Format(ConstantMessages
                .SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
           ICard card= cardFactory.CreateCard(type, name);
            cardRepository.Add(card);
            return string.Format(ConstantMessages
                .SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = playerRepository.Find(username);
            ICard card = cardRepository.Find(cardName);
            player.CardRepository.Add(card);
            return string.Format(ConstantMessages
                .SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = playerRepository.Find(attackUser);
            IPlayer enemy = playerRepository.Find(enemyUser);
            battleField.Fight(attacker, enemy);
            return string.Format(ConstantMessages
                .FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages
                    .PlayerReportInfo, player.Username,
                    player.Health, player.CardRepository.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages
                        .CardReportInfo, card.Name, card.DamagePoints));
                }
                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
