pub fn quicksort(slice: &mut [i32]) {
    if slice.len() < 2 {
        return
    }

    let pivot = slice[0];
    let split_index = partition(slice, pivot);

    let (left, right) = slice.split_at_mut(split_index);

    quicksort(left);
    quicksort(right);
}

#[test]
fn quicksort_sorts_permutations() {
    let expected = vec![1, 2, 3, 3, 4, 5, 5];

    use itertools::Itertools;

    for permutation in expected.iter().permutations(expected.len()).unique() {
        let mut actual: Vec<i32> = permutation.iter().map(|i| **i).collect();

        quicksort(&mut actual);

        assert_eq!(expected, actual);
    }
}

#[test]
fn quicksort_343_sets_334() {
    let mut array = vec![3, 4, 3];

    quicksort(&mut array);

    assert_eq!(vec![3, 3, 4], array);
}

#[test]
fn quicksort_for_empty_array_does_nothing() {
    let mut array = vec![];

    quicksort(&mut array);

    assert_eq!(Vec::<i32>::new(), array);
}

#[test]
fn quicksort_for_1_element_array_does_nothing() {
    let mut array = vec![1];

    quicksort(&mut array);

    assert_eq!(vec![1], array);
}

fn partition(slice: &mut [i32], pivot: i32) -> usize {
    let mut left = 0;
    let mut right = slice.len() - 1;

    while try_swap(slice, &mut left, &mut right, pivot) { }

    right + 1
}

#[test]
fn partition_12_returns_1() {
    let mut array = vec![1, 2];
    let pivot = 1;

    let split_index = partition(&mut array, pivot);

    assert_eq!(vec![1, 2], array);
    assert_eq!(1, split_index);
}

#[test]
fn partition_21_returns_1() {
    let mut array = vec![2, 1];
    let pivot = 1;

    let split_index = partition(&mut array, pivot);

    assert_eq!(vec![1, 2], array);
    assert_eq!(1, split_index);
}

#[test]
fn partition_22_returns_1() {
    let mut array = vec![2, 2];
    let pivot = 2;

    let split_index = partition(&mut array, pivot);

    assert_eq!(vec![2, 2], array);
    assert_eq!(1, split_index);
}

fn try_swap(slice: &mut [i32], left: &mut usize, right: &mut usize, pivot: i32) -> bool {
    *left = find_next_left(slice, *left, pivot);
    *right = find_next_right(slice, *right, pivot);

    if left >= right {
        return false
    }

    slice.swap(*left, *right);
    *left += 1;
    *right -= 1;

    true
}

#[test]
fn trying_swap_343_step_1() {
    let mut array = vec![3, 4, 3];
    let mut left = 0;
    let mut right = 2;
    let pivot = 3;

    let do_continue = try_swap(&mut array, &mut left, &mut right, pivot);

    assert_eq!(vec![3, 4, 3], array);
    assert_eq!(1, left);
    assert_eq!(1, right);
    assert_eq!(true, do_continue);
}

#[test]
fn trying_swap_343_step_2() {
    let mut array = vec![3, 4, 3];
    let mut left = 1;
    let mut right = 1;
    let pivot = 3;

    let do_continue = try_swap(&mut array, &mut left, &mut right, pivot);

    assert_eq!(vec![3, 4, 3], array);
    assert_eq!(1, left);
    assert_eq!(0, right);
    assert_eq!(false, do_continue);
}

#[test]
fn trying_swap_21_swaps_and_sets_left_to_1_right_to_0() {
    let mut array = vec![2, 1];
    let mut left = 0;
    let mut right = 1;

    let do_continue = try_swap(&mut array, &mut left, &mut right, 1);

    assert_eq!(vec![1, 2], array);
    assert_eq!(1, left);
    assert_eq!(0, right);
    assert_eq!(true, do_continue);
}

#[test]
fn trying_swap_22_swaps_and_sets_left_to_1_right_to_0() {
    let mut array = vec![2, 2];
    let mut left = 0;
    let mut right = 1;

    let do_continue = try_swap(&mut array, &mut left, &mut right, 2);

    assert_eq!(vec![2, 2], array);
    assert_eq!(1, left);
    assert_eq!(0, right);
    assert_eq!(true, do_continue);
}

#[test]
fn trying_swap_12_after_previous_test_does_nothing() {
    let mut array = vec![1, 2];
    let mut left = 1;
    let mut right = 0;

    let do_continue = try_swap(&mut array, &mut left, &mut right, 2);

    assert_eq!(vec![1, 2], array);
    assert_eq!(1, left);
    assert_eq!(0, right);
    assert_eq!(false, do_continue);
}

#[test]
fn trying_swap_12_sets_left_and_right_to_0() {
    let mut array = vec![1, 2];
    let mut left = 0;
    let mut right = 1;

    let do_continue = try_swap(&mut array, &mut left, &mut right, 1);

    assert_eq!(vec![1, 2], array);
    assert_eq!(0, left);
    assert_eq!(0, right);
    assert_eq!(false, do_continue);
}

fn find_next_left(slice: &[i32], left: usize, pivot: i32) -> usize {
    let mut i = left;

    while slice[i] < pivot {
        i += 1
    }

    i
}

fn find_next_right(slice: &[i32], right: usize, pivot: i32) -> usize {
    let mut i = right;

    while slice[i] > pivot {
        i -= 1
    }

    i
}

#[test]
fn finding_next_left_result_points_to_greater_than_pivot() {
    let pivot = 3;
    let array = vec![0, 1, 4, pivot, 2, 5];
    let mut left = 0;

    left = find_next_left(&array, left, pivot);

    assert_eq!(2, left);
}

#[test]
fn finding_next_left_result_points_to_pivot() {
    let pivot = 3;
    let array = vec![0, 1, 2, pivot, 4, 5];
    let mut left = 0;

    left = find_next_left(&array, left, pivot);

    assert_eq!(3, left);
}