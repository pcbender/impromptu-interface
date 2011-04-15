﻿// 
//  Copyright 2011  Ekon Benefits
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImpromptuInterface.Dynamic;

namespace ImpromptuInterface
{

 

    /// <summary>
    /// Object that stores a context with a target for dynamic invocation
    /// </summary>
    [Serializable]
    public class InvokeContext
    {

        /// <summary>
        /// Create Function can set to variable to make cleaner syntax;
        /// </summary>
        public static readonly Func<object, object, InvokeContext> CreateContext =
            Return<InvokeContext>.Arguments<object, object>((t, c) => new InvokeContext(t, c));

        /// <summary>
        /// Create Function can set to variable to make cleaner syntax;
        /// </summary>
        public static readonly Func<Type, InvokeContext> CreateStatic =
           Return<InvokeContext>.Arguments<Type>((t) => new InvokeContext(t, true, null));
       
        /// <summary>
        /// Create Function can set to variable to make cleaner syntax;
        /// </summary>
        public static readonly Func<Type, object, InvokeContext> CreateStaticWithContext =
   Return<InvokeContext>.Arguments<Type, object>((t, c) => new InvokeContext(t, true, c));


        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        /// <value>The target.</value>
        public object Target { get; protected set; }
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public Type Context { get; protected set; }

        public bool StaticContext { get; protected set; }

        public InvokeContext(Type target, bool staticContext, object context)
        {
            if (context != null && !(context is Type))
            {
                context = context.GetType();
            }
            Target = target;
            Context = ((Type)context) ?? target;
            StaticContext = staticContext;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvokeContext"/> class.
        /// </summary>
        /// <param name="Target">The target.</param>
        /// <param name="context">The context.</param>
        public InvokeContext(object Target, object context)
        {
            this.Target = Target;

            if (context != null && !(context is Type))
            {
                context = context.GetType();
            }

            Context = (Type)context;
        }
    }
}
