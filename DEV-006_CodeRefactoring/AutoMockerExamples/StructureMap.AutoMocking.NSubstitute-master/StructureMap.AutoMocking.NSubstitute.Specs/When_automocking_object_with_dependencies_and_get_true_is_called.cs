﻿using Machine.Specifications;
using NSubstitute;

namespace StructureMap.AutoMocking.NSubstitute.Specs
{
    [Subject(typeof(NSubstituteAutoMockerBuilder))]
    public class When_automocking_object_with_dependencies_and_get_true_is_called : With<TestObjectWithDependencies>
    {
        static bool _result;
        Establish context = () => For<IProvideTrueValue>().GetTrue().Returns(true);

        Because of = () => _result = Subject.GetTrue();

        It should_request_value_from_mocked_true_provider_object = () => For<IProvideTrueValue>().Received().GetTrue();
        It should_return_the_value_returned_by_mock_provider = () => _result.ShouldBeTrue();
    }
}
