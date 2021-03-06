// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Xml.XPath;

namespace MS.Internal.Xml.XPath
{
    internal class Axis : AstNode
    {
        private AxisType axisType;
        private AstNode input;
        private string prefix;
        private string name;
        private XPathNodeType nodeType;
        protected bool abbrAxis;

        public enum AxisType
        {
            Ancestor,
            AncestorOrSelf,
            Attribute,
            Child,
            Descendant,
            DescendantOrSelf,
            Following,
            FollowingSibling,
            Namespace,
            Parent,
            Preceding,
            PrecedingSibling,
            Self,
            None
        };

        // constructor
        public Axis(AxisType axisType, AstNode input, string prefix, string name, XPathNodeType nodetype)
        {
            Debug.Assert(prefix != null);
            Debug.Assert(name != null);
            this.axisType = axisType;
            this.input = input;
            this.prefix = prefix;
            this.name = name;
            this.nodeType = nodetype;
        }

        // constructor
        public Axis(AxisType axisType, AstNode input)
            : this(axisType, input, string.Empty, string.Empty, XPathNodeType.All)
        {
            this.abbrAxis = true;
        }

        public override AstType Type { get { return AstType.Axis; } }

        public override XPathResultType ReturnType { get { return XPathResultType.NodeSet; } }

        public AstNode Input
        {
            get { return input; }
        }

        public string Prefix { get { return prefix; } }
        public string Name { get { return name; } }
        public XPathNodeType NodeType { get { return nodeType; } }
        public AxisType TypeOfAxis { get { return axisType; } }
        public bool AbbrAxis { get { return abbrAxis; } }
    }
}
