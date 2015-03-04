using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTest
{
    public class HatesRelationship : Relationship<HatesData>, IRelationshipAllowingSourceNode<Person>,
IRelationshipAllowingTargetNode<Person>
    {
        public static readonly string TypeKey = "HATES";

        public HatesRelationship(NodeReference targetNode, HatesData data)
            : base(targetNode, data)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
