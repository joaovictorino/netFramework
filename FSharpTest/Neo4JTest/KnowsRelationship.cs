using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neo4JTest
{
    public class KnowsRelationship : Relationship, IRelationshipAllowingSourceNode<Person>,
    IRelationshipAllowingTargetNode<Person>
    {
        public static readonly string TypeKey = "KNOWS";

        public KnowsRelationship(NodeReference targetNode)
            : base(targetNode)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
