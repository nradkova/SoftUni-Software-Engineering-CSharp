using System;
using System.Linq;

using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException
                    ("Player is dead!");
            }
            EnhancePlayerBeforeFight(attackPlayer);
            EnhancePlayerBeforeFight(enemyPlayer);
            AttackInOrderUntillOneIsDead(attackPlayer, enemyPlayer);
        }

        private  void AttackInOrderUntillOneIsDead(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            int damagePointsAttacker = attackPlayer
                            .CardRepository.Cards.Sum(x => x.DamagePoints);
            int damagePointsEnemy = enemyPlayer
                .CardRepository.Cards.Sum(x => x.DamagePoints);

            IPlayer damaged = enemyPlayer;
            int damagePoints = damagePointsAttacker;

            while (attackPlayer.IsDead == false
                && enemyPlayer.IsDead == false)
            {
                damaged.TakeDamage(damagePoints);

                if (damaged.Username == enemyPlayer.Username)
                {
                    damaged = attackPlayer;
                    damagePoints = damagePointsEnemy;
                }
                else
                {
                    damaged = enemyPlayer;
                    damagePoints = damagePointsAttacker;
                }
            }
        }

        private void EnhancePlayerBeforeFight(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += 40;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            player.Health += player
                .CardRepository.Cards.Sum(x => x.HealthPoints);
        }
    }
}
