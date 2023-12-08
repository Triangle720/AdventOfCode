namespace AdventOfCode2023
{
    public class Day7 : IDay
    {
        private readonly string[] _input;

        public Day7(string[] input) => _input = input;

        public double Part1() => ProcessPlayers(ReadPlayersFromInput());

        public double Part2()
        {
            var players = ReadPlayersFromInput().ToArray();
            Array.ForEach(players, x => x.Hand.SetBestPossibleKindWithJokers());
            return ProcessPlayers(players);
        }

        private int ProcessPlayers(Player[] players)
        {
            var processed = players
                .OrderBy(x => x.Hand.Kind)
                .ThenBy(x => x.Hand)
                .ToList();

            return processed.Select((x, index) => x.Bid * (index + 1)).Sum();
        }


        private Player[] ReadPlayersFromInput()
        {
            return _input.Select(x =>
            {
                var splittedLine = x.Split(' ');
                return new Player(splittedLine[0], splittedLine[1]);
            }).ToArray();
        }

        #region Types & helpers

        private class Player(string cards, string bid)
        {
            public Hand Hand { get; private set; } = new Hand(cards);
            public int Bid { get; init; } = int.Parse(bid);
        }

        private enum HandKind
        {
            HighCard, OnePair, TwoPair, ThreeOfAKind, Fullhouse, FourOfAKind, FiveOfAKind
        }

        private class Hand(string cards) : IComparable<Hand>
        {
            public string Cards { get; private set; } = cards;
            public HandKind Kind { get; private set; } = GetHandKind(cards.ToCharArray());
            public bool HasJokers { get; private set; } = false;

            public void SetBestPossibleKindWithJokers()
            {
                if (!Cards.Contains('J'))
                {
                    return;
                }

                if (Cards.All(x => x.Equals('J')))
                {
                    HasJokers = true;
                    return;
                }

                var cardsWithOccurences = Cards
                    .Where(x => !x.Equals('J'))
                    .Distinct()
                    .Select(x => (Card: x, Count: Cards.Count(y => x.Equals(y))));

                var bestCard = cardsWithOccurences
                    .Where(x => x.Count == cardsWithOccurences.Select(x => x.Count).Max())
                    .Select(x => (x.Card, Value: CardToNumber(x.Card, false)))
                    .OrderByDescending(x => x.Value)
                    .First();

                Kind = GetHandKind(Cards.Replace('J', bestCard.Card).ToCharArray());
                HasJokers = true;
            }

            private static HandKind GetHandKind(char[] cards)
            {
                var distinctCards = cards.Distinct();
                return distinctCards.Count() switch
                {
                    1 => HandKind.FiveOfAKind,
                    2 => cards.Count(x => x.Equals(distinctCards.First())) is 4 or 1
                        ? HandKind.FourOfAKind
                        : HandKind.Fullhouse,
                    3 => distinctCards.Select(x => cards.Count(y => y.Equals(x))).Contains(3)
                        ? HandKind.ThreeOfAKind
                        : HandKind.TwoPair,
                    4 => HandKind.OnePair,
                    _ => HandKind.HighCard,
                };
            }

            public static int CardToNumber(char card, bool hasJokers)
            {
                if (char.IsDigit(card)) return card - 48;

                return card switch
                {
                    'T' => 10,
                    'J' => hasJokers ? 1 : 11,
                    'Q' => 12,
                    'K' => 13,
                    'A' => 14,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            public int CompareTo(Hand? other)
            {
                if (other is null || other.Cards.Length != Cards.Length)
                {
                    return -1;
                }

                for (var i = 0; i < Cards.Length; i++)
                {
                    var comparisonResult = CardToNumber(Cards[i], HasJokers) - CardToNumber(other.Cards[i], other.HasJokers);
                    if (comparisonResult != 0)
                    {
                        return comparisonResult;
                    }
                }

                return 0;
            }
        };

        #endregion
    }
}
