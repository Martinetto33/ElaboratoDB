﻿namespace DatabaseProject.model.code
{
    public class Player(string id, string name, string surname)
    {
        public string Name { get; } = name;
        public string Surname { get; } = surname;
        public string Id { get; } = id;

        /// <summary>
        /// A set of all the <see cref="Account"/>s that this player has.
        /// </summary>
        public ISet<Account> Accounts { get; } = new HashSet<Account>();
    }
}
