using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GoF_TryOut.Commands.Refactored {
    public class Command<T> : ICommand {
        private readonly MethodInfo methodInfo;

        public Command(Expression<Action<T>> funs) {
            var name = funs.Body as MethodCallExpression;
            var methodName = name.Method.Name;

            methodInfo = typeof(T).GetMethod(methodName);
        }

        public void Execute(object item) {
            methodInfo.Invoke(item, new object[] {});
        }
    }
}